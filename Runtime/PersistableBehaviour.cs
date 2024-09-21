using InitialFramework.IO;
using UnityEngine;

namespace InitialSolution.Persistence
{
    /// <summary>  
    /// �ɳ־û���Ϊ��
    /// <br>���ǻ��࣬����ʵ�ֿɳ־û���Ϊ��ͨ�ù��ܡ�</br>
    /// 
    /// <para>�̳��� <see cref="MonoBehaviour"/>��ʹ���ܹ��� Unity �༭������Ϊ������й���</para>
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
