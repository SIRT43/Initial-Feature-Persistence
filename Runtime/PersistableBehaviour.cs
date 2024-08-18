using FTGAMEStudio.InitialFramework.IO;
using UnityEngine;

namespace FTGAMEStudio.InitialSolution.Persistence
{
    /// <summary>  
    /// �ɳ־û���Ϊ��
    /// <br>���ǻ��࣬����ʵ�ֿɳ־û���Ϊ��ͨ�ù��ܡ�</br>
    /// 
    /// <para>�̳��� <see cref="MonoBehaviour"/>��ʹ���ܹ��� Unity �༭������Ϊ������й���</para>
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
