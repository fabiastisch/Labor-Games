using DungeonGeneration.Scripts;
using UnityEngine;

namespace Dungeon
{
    public class DungeonGenerator : MonoBehaviour
    {
        public GameObject spawn;
        public GameObject portal;
        public TilemapVisualizer tilemapVisualizer;
        [Header("Select Generator")] public DungeonGeneratorType generatorType;
        [HideInInspector] public DungeonGeneratorType currentGeneratorType;
    }

    public enum DungeonGeneratorType
    {
        CorridorFirst = 0,
        RoomDungeon = 1,
        RoomFirst = 2,
        SimpleRandomWalk = 3
    }
}