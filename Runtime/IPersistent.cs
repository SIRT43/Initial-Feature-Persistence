using System.Threading.Tasks;

namespace FTGAMEStudio.InitialSolution.Persistence
{
    public interface IPersistentReader
    {
        public bool Read();
    }

    public interface IPersistentAsyncReader
    {
        public Task<bool> ReadAsync();
    }


    public interface IPersistentWriter
    {
        public bool Write();
    }

    public interface IPersistentAsyncWriter
    {
        public Task<bool> WriteAsync();
    }


    public interface IPersistent : IPersistentReader, IPersistentWriter
    {
        public bool Delete();
    }


    public interface IPersistentAsync : IPersistentAsyncReader, IPersistentAsyncWriter { }
}
