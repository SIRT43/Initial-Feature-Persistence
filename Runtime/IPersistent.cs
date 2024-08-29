using FTGAMEStudio.InitialFramework.IO;

namespace FTGAMEStudio.InitialSolution.Persistence
{
    public interface IPersistentReader : IFileReference
    {
        public bool Read();
    }

    public interface IPersistentWriter : IFileReference
    {
        public void Write();
    }

    public interface IPersistent : IPersistentReader, IPersistentWriter, IFileReference
    {
        public bool Delete();
    }
}
