using InitialFramework.IO;
using InitialSolution.Persistence.Serialization;
using System;
using UnityEngine;

namespace InitialSolution.Persistence.Persisting
{
    [Serializable]
    public abstract class Persistent : IPersistable, IFileReference
    {
        public abstract UnityFile FileLocation { get; }


        public virtual bool Read() =>
            Json.FromFile(this, FileLocation);

        public virtual void Write() =>
            Json.ToFile(this, FileLocation);

        public virtual bool Delete() =>
            FileLocation.Delete();


#if UNITY_EDITOR
        public virtual void DisplayInExplorer() => Application.OpenURL(FileLocation.FullPath);
#endif
    }
}