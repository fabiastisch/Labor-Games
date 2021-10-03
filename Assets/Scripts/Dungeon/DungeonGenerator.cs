using DungeonGeneration;

namespace Dungeon {
    public class DungeonGenerator : SimpleRandomWalkDungeonGenerator {
        private void Awake() {
            GenerateDungeon();
        }
    }
}