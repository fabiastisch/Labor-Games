using System;
using Dungeon;
using DungeonGeneration;
using DungeonGeneration.Scripts;
using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomEditor(typeof(DungeonGenerator), true)]
    public class DungeonGeneratorEditor : UnityEditor.Editor {
        private DungeonGenerator _generator;


        private void OnEnable() {
            _generator = (DungeonGenerator)target;
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            if (_generator.currentGeneratorType.Equals(_generator.generatorType)) return;
            Type type = getClass(_generator.currentGeneratorType);
            Component component = _generator.gameObject.GetComponent(type);
            if (component) {
                DestroyImmediate(component, false);
            }
            
            _generator.gameObject.AddComponent(getClass(_generator.generatorType));
            _generator.currentGeneratorType = _generator.generatorType;
        }

        private Type getClass(DungeonGeneratorType type) {
            switch (type) {
                case DungeonGeneratorType.CorridorFirst:
                    return typeof(CorridorFirstDungeonGenerator);
                case DungeonGeneratorType.RoomDungeon:
                    return typeof(RoomDungeonGenerator);
                case DungeonGeneratorType.RoomFirst:
                    return typeof(RoomFirstDungeonGenerator);
                case DungeonGeneratorType.SimpleRandomWalk:
                    return typeof(SimpleRandomWalkDungeonGenerator);
            }

            return null;
        }
    }
}