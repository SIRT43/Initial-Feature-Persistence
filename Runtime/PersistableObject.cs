using InitialFramework.IO;
using UnityEngine;

namespace InitialSolution.Persistence
{
    /// <summary>  
    /// �ɳ־û�����
    /// <br>���ǻ��࣬����ʵ�ֿɳ־û������ͨ�ù��ܡ�</br>
    /// 
    /// <para>�̳��� <see cref="ScriptableObject"/>��ʹ���ܹ��� Unity �༭������Ϊ�ʲ����й���</para>
    /// </summary>  
    public abstract class PersistableObject : ScriptableObject, IPersistable
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
