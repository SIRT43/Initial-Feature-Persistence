using InitialFramework.IO;

namespace InitialSolution.Persistence.Persisting
{
    public interface IPersistable : IFileReference
    {
        void Write();
        bool Read();

        bool Delete();

#if UNITY_EDITOR
        void DisplayInExplorer();
#endif
    }
}
