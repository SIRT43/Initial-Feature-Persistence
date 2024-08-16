using FTGAMEStudio.InitialFramework.IO;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace FTGAMEStudio.InitialSolution.Persistence
{
    [Serializable]
    public abstract class Persistent : IPersistent, IPersistentAsync, IFileReference
    {
        public abstract FilePath FileLocation { get; }

        private readonly Timer writer;
        public readonly bool autoWrite = false;

        private bool enableWriter = false;
        public bool EnableWriter
        {
            get => enableWriter;
            set
            {
                if (value) writer.Start();
                else writer.Stop();

                enableWriter = value;
            }
        }


        public virtual bool Read() =>
            IFJson.FromFile(FileLocation, this);

        public virtual async Task<bool> ReadAsync() =>
            await IFJson.FromFileAsync(FileLocation, this);

        public virtual bool Write() =>
            IFJson.ToFile(FileLocation, this);

        public virtual async Task<bool> WriteAsync() =>
            await IFJson.ToFileAsync(FileLocation, this);


        public virtual bool Delete() =>
            IFFile.Delete(FileLocation);


        protected Persistent() { }

        protected Persistent(bool read)
        {
            if (read) Read();
        }

        protected Persistent(bool read, double interval = 60000) : this(interval)
        {
            if (read) Read();
        }

        protected Persistent(double interval = 60000)
        {
            writer = new()
            {
                Interval = interval,
                AutoReset = true,
            };
            writer.Elapsed += Writer_Elapsed;

            autoWrite = true;
        }


        private void Writer_Elapsed(object sender, ElapsedEventArgs e) => Write();

        ~Persistent()
        {
            if (!autoWrite) return;

            writer.Stop();
            writer.Close();
        }
    }
}
