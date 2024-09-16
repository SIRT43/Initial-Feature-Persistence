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

            if (GUILayout.Button("读取"))
            {
                if (EditorUtility.DisplayDialog("读取选定文件？", $"{target.FileLocation.FullPath}\n\n您无法撤销文件读取操作。", "确定", "取消")) target.Read();
            }

            if (GUILayout.Button("写入"))
            {
                if (EditorUtility.DisplayDialog("写入选定文件？", $"{target.FileLocation.FullPath}\n\n您无法撤销文件写入操作。", "确定", "取消")) target.Write();
            }
            if (GUILayout.Button("删除"))
            {
                if (EditorUtility.DisplayDialog("删除选定文件？", $"{target.FileLocation.FullPath}\n\n您无法撤销文件删除操作。", "确定", "取消")) target.Delete();
            }

            GUILayout.EndHorizontal();

            if (GUILayout.Button("在资源管理器中显示 (或打开文件)"))
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
