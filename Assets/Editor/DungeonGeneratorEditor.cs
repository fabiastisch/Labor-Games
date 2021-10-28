using Dungeon.DungeonGeneration;
using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomEditor(typeof(DungeonGenerator), true)]
    public class RandomDungeonGeneratorEditor : UnityEditor.Editor {
        private DungeonGenerator _generator;

        private void Awake() {
            _generator = (DungeonGenerator)target;
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            if (GUILayout.Button("Create Dungeon")) {
                _generator.GenerateDungeon();
            }

            if (GUILayout.Button("Clear Dungeon")) {
                _generator.ClearDungeon();
                //_generator.ClearObjectsImmediate();
            }
            
            if (GUILayout.Button("Activate BonusLevel")) {
                _generator.ActivateBonusRoom();
                //_generator.ClearObjectsImmediate();
            }
            if (GUILayout.Button("Deactivate BonusLevel")) {
                _generator.ActivateBonusRoom(false);
                //_generator.ClearObjectsImmediate();
            }
        }
    }
}