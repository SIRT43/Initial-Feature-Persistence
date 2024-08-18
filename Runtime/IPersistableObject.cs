using FTGAMEStudio.InitialFramework.IO;

namespace FTGAMEStudio.InitialSolution.Persistence
{
    public interface IPersistableObject : IPersistent, IFileReference
    {
#if UNITY_EDITOR
        public void DisplayInExplorer();
#endif
    }
}
