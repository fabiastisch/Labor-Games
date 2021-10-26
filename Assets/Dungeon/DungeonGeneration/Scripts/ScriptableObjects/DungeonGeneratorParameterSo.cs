using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "DungeonGeneratorParameters_", menuName = "PCG/DungeonParameter")]
    public class DungeonGeneratorParameterSo : ScriptableObject
    {
        public DungeonGeneratorType generatorType;

        public Vector2Int startPosition = Vector2Int.zero;

        #region RoomDungeon

        [Header("Room Dungeon")] public bool isRoomDungeon;

        [Header("Rectangular Room")] public bool createRectangularRoom;

        public int with = 14;
        public int height = 14;

        [Header("Round Room")]
        public bool createRoundRoom;

        public float radius = 10;

        #endregion

        #region RoomFirstDungeonGen

        [Header("RoomFirstDungeonGen")] public int minRoomWidth = 8;
        public int minRoomHeight = 8;
        public int dungeonWidth = 25, dungeonHeight = 25;
        [Range(0, 10)] public int dungeonOffset = 1;
        public bool randomWalkRooms = false;
        public int corridorWidth = 3;

        [Header("Trap Room")] [Range(0, 4)] public float trapRoomChance;

        [Header("Bonus Room / Secret Room")] [Range(0, 1)]
        public float bonusRoomChance;

        public Dir direction = Dir.Random;
        public int bonusRoomWidth = 10, bonusRoomHeight = 10;
        public int bonusRoomOffset = 5;

        [Header("Corridor Traps")] public Direction corridorTrapSpawnDirection;

        [Range(0, 2)] public float corridorTrapChance;

        #endregion

        #region SimpleWalkDungeonGen
        [Header("SimpleWalkDungeonGen")]

        public int iterations = 10;
        public int walkLength = 10;

        [Tooltip("If True, the Dungeon Will more Expand, else the Starting Point will get more Covered")]
        public bool startRandomlyEachIteration = true;

        #endregion

        #region CorridorFirstDungeonGen
        [Header("CorridorFirstDungeonGen")]
        public int corridorLength = 14, corridorCount = 5;
        [Range(0.1f, 1)] public float roomPercent = 0.8f;

        #endregion
    }
}