using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "RoomFirstParameters_",
        menuName = "PCG/RoomFirst")]
    public class RoomFirstDungeonGeneratorSo : SimpleRandomWalkDungeonGeneratorSo
    {
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

        protected override void OnValidate()
        {
            generatorType = DungeonGeneratorType.RoomFirst;
        }
    }
}