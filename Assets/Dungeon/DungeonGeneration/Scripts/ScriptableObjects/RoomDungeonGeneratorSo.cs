using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "RoomDungeonGeneratorParameters_", menuName = "PCG/RoomDungeon")]
    public class RoomDungeonGeneratorSo : AbstractDungeonGeneratorParameterSo
    {
        [Header("Room Dungeon")] [Header("Rectangular Room")]
        public bool createRectangularRoom;

        public int with = 14;
        public int height = 14;

        [Header("Round Room")] public bool createRoundRoom;

        public float radius = 10;

        private void OnValidate()
        {
            generatorType = DungeonGeneratorType.RoomDungeon;
        }
    }
}