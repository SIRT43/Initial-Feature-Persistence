using FTGAMEStudio.InitialFramework.IO;

namespace FTGAMEStudio.InitialSolution.Persistence
{
    public interface IPersistentReader : IFileReference
    {
        bool Read();
    }

    public interface IPersistentWriter : IFileReference
    {
        void Write();
    }

    public interface IPersistent : IPersistentReader, IPersistentWriter, IFileReference
    {
        bool Delete();
    }
}
