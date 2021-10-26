using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    public class DungeonGeneratorParameterSo : ScriptableObject
    {
        public DungeonGeneratorType generatorType;

        public Vector2Int startPosition = Vector2Int.zero;

        #region RoomDungeon

        [Header("Room Dungeon")] [SerializeField]
        public bool isRoomDungeon;

        [Header("Rectangular Room")] [SerializeField]
        public bool createRectangularRoom;

        [SerializeField] public int with = 14;
        [SerializeField] public int height = 14;

        [Header("Round Room")] [SerializeField]
        public bool createRoundRoom;

        [SerializeField] public float radius = 10;

        #endregion

        #region RoomFirstDungeonGen

        public int minRoomWidth = 8, minRoomHeight = 8;
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

        public int iterations = 10;
        public int walkLength = 10;

        [Tooltip("If True, the Dungeon Will more Expand, else the Starting Point will get more Covered")]
        public bool startRandomlyEachIteration = true;

        #endregion

        #region CorridorFirstDungeonGen

        public int corridorLength = 14, corridorCount = 5;
        [Range(0.1f, 1)] public float roomPercent = 0.8f;

        #endregion
    }
}