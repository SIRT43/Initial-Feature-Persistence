namespace FTGAMEStudio.InitialSolution.Persistence
{
    public interface IPersistentReader
    {
        public bool Read();
    }

    public interface IPersistentWriter
    {
        public void Write();
    }

    public interface IPersistent : IPersistentReader, IPersistentWriter
    {
        public bool Delete();
    }
}
