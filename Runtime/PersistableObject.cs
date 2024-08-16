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
    /// �ɳ־û�����
    /// <br>���ǻ��࣬����ʵ�ֿɳ־û������ͨ�ù��ܡ�</br>
    /// 
    /// <para>�̳��� <see cref="ScriptableObject"/>��ʹ���ܹ��� Unity �༭������Ϊ�ʲ����й���</para>
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
