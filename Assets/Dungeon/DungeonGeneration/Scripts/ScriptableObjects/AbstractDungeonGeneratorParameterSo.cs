using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    public abstract class AbstractDungeonGeneratorParameterSo : ScriptableObject
    {
        [Header("Enemies")]
        public DungeonEnemiesSO enemiesSo;

        [Header("Generator")]
        public DungeonGeneratorType generatorType;
        public Vector2Int startPosition = Vector2Int.zero;

        [Header("Color")] public Color floorColor;
        public Color wallColor;
        public bool overrideDefaultColor = false;

        [Header("Spawn&Portal")] public Vector2 spawnPosition;
        public bool useSpawn;
        public Vector2 portalPosition;
        public bool usePortal;
    }
}