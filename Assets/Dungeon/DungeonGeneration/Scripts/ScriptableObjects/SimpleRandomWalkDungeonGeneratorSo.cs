using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "SimpleRandomWalkParameters_", menuName = "PCG/SimpleRandomWalk")]

    public class SimpleRandomWalkDungeonGeneratorSo : AbstractDungeonGeneratorParameterSo
    {
        [Header("SimpleWalkDungeonGen")] public int iterations = 10;
        public int walkLength = 10;

        [Tooltip("If True, the Dungeon Will more Expand, else the Starting Point will get more Covered")]
        public bool startRandomlyEachIteration = true;

        protected virtual void OnValidate()
        {
            generatorType = DungeonGeneratorType.SimpleRandomWalk;
        }
    }
}