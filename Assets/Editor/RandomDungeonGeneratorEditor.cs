using DungeonGeneration;
using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomEditor(typeof(AbstractDungeonGenerator), true)]
    public class RandomDungeonGeneratorEditor : UnityEditor.Editor {
        private AbstractDungeonGenerator _generator;

        private void Awake() {
            _generator = (AbstractDungeonGenerator)target;
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (GUILayout.Button("Create Dungeon")) {
                _generator.GenerateDungeon();
            }

            if (GUILayout.Button("Clear Dungeon")) {
                _generator.ClearDungeon();
            }
        }
    }
}