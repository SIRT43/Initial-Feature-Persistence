using FTGAMEStudio.InitialFramework.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace FTGAMEStudio.InitialSolution.Persistence
{
    public interface IPersistableObject : IPersistent, IFileReference
    {
#if UNITY_EDITOR
        public void DisplayInExplorer();
#endif
    }

    /// <summary>  
    /// 可持久化对象。
    /// <br>它是基类，用于实现可持久化对象的通用功能。</br>
    /// 
    /// <para>继承自 <see cref="ScriptableObject"/>，使其能够在 Unity 编辑器中作为资产进行管理。</para>
    /// </summary>  
    public abstract class PersistableObject : ScriptableObject, IPersistableObject, IPersistentAsync
    {
        public abstract FilePath FileLocation { get; }


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


#if UNITY_EDITOR
        public virtual void DisplayInExplorer() => Application.OpenURL(FileLocation.FullPath);
#endif
    }
}
