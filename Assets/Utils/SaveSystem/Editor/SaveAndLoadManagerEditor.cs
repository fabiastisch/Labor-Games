using UnityEditor;
using UnityEngine;

namespace Utils.SaveSystem.Editor
{
    [CustomEditor(typeof(SaveAndLoadManager), true)]
    public class SaveAndLoadManagerEditor : UnityEditor.Editor
    {
        private SaveAndLoadManager manager;

        private void Awake()
        {
            manager = (SaveAndLoadManager) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Save"))
            {
                manager.Save();
            }

            if (GUILayout.Button("Load"))
            {
                manager.Load();
            }
        }
    }
}