using InitialFramework.IO;
using UnityEngine;

namespace InitialSolution.Persistence
{
    /// <summary>  
    /// 可持久化行为。
    /// <br>它是基类，用于实现可持久化行为的通用功能。</br>
    /// 
    /// <para>继承自 <see cref="MonoBehaviour"/>，使其能够在 Unity 编辑器中作为组件进行管理。</para>
    /// </summary>  
    public abstract class PersistableBehaviour : MonoBehaviour, IPersistable
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
