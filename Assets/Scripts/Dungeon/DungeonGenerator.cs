using DungeonGeneration;
using UnityEngine;

namespace Dungeon {
    public class DungeonGenerator : SimpleRandomWalkDungeonGenerator {
        [SerializeField] private bool generateOnPlay = true;

        private void Awake() {
            if (generateOnPlay) {
                GenerateDungeon();
            }
        }
    }
}