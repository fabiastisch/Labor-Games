using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "RoomDungeonGeneratorParameters_", menuName = "PCG/RoomDungeonGeneratorParameters")]
    public class RoomDungeonGeneratorSo : ScriptableObject
    {
        [Header("Room Dungeon")] [SerializeField]
        public bool isRoomDungeon;

        [Header("Rectangular Room")] [SerializeField]
        public bool createRectangularRoom;

        [SerializeField] public int with = 14;
        [SerializeField] public int height = 14;

        [Header("Round Room")] [SerializeField]
        public bool createRoundRoom;

        [SerializeField] public float radius = 10;
    }
}