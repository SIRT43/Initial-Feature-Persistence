using FTGAMEStudio.InitialFramework.IO;
using UnityEngine;

namespace FTGAMEStudio.InitialSolution.Persistence
{
    /// <summary>  
    /// 可持久化行为。
    /// <br>它是基类，用于实现可持久化行为的通用功能。</br>
    /// 
    /// <para>继承自 <see cref="MonoBehaviour"/>，使其能够在 Unity 编辑器中作为组件进行管理。</para>
    /// </summary>  
    public abstract class PersistableBehaviour : MonoBehaviour, IPersistableObject
    {
        public abstract UnityFile FileLocation { get; }


        public virtual bool Read() =>
            IFJson.FromFile(FileLocation, this);

        public virtual void Write() =>
            IFJson.ToFile(FileLocation, this);

        public virtual bool Delete() =>
            FileLocation.Delete();


#if UNITY_EDITOR
        public virtual void DisplayInExplorer() => Application.OpenURL(FileLocation.FullPath);
#endif
    }
}
