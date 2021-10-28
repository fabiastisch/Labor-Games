using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "CorridorFirstParameters_", menuName = "PCG/CorridorFirst")]
    public class CorridorFirstDungeonGeneratorSo : SimpleRandomWalkDungeonGeneratorSo
    {
        [Header("CorridorFirstDungeonGen")] public int corridorLength = 14, corridorCount = 5;
        [Range(0.1f, 1)] public float roomPercent = 0.8f;
        
        protected override void OnValidate()
        {
            generatorType = DungeonGeneratorType.CorridorFirst;
        }
    }
}