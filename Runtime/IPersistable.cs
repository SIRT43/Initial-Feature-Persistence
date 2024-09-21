using InitialFramework.IO;

namespace InitialSolution.Persistence
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
