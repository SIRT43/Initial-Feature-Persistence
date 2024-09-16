#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace InitialSolution.Persistence.Persisting
{
    public abstract class IPersistableObject_Inspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            IPersistable target = this.target as IPersistable;

            EditorGUILayout.Space();

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("��ȡ"))
            {
                if (EditorUtility.DisplayDialog("��ȡѡ���ļ���", $"{target.FileLocation.FullPath}\n\n���޷������ļ���ȡ������", "ȷ��", "ȡ��")) target.Read();
            }

            if (GUILayout.Button("д��"))
            {
                if (EditorUtility.DisplayDialog("д��ѡ���ļ���", $"{target.FileLocation.FullPath}\n\n���޷������ļ�д�������", "ȷ��", "ȡ��")) target.Write();
            }
            if (GUILayout.Button("ɾ��"))
            {
                if (EditorUtility.DisplayDialog("ɾ��ѡ���ļ���", $"{target.FileLocation.FullPath}\n\n���޷������ļ�ɾ��������", "ȷ��", "ȡ��")) target.Delete();
            }

            GUILayout.EndHorizontal();

            if (GUILayout.Button("����Դ����������ʾ (����ļ�)"))
                target.DisplayInExplorer();

            EditorGUILayout.Space();

            EditorGUILayout.HelpBox(
    @"**Important Note**:  
    - If you are changing the file path through the inspector or code, it's recommended to first use the 'Delete' button to avoid any leftover files.  
    - This will ensure a clean transition to the new file location.  
  
**Current File Location**:  
    " + target.FileLocation.FullPath,
    MessageType.Info);
        }
    }
}
#endif
