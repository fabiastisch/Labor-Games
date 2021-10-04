using UnityEngine;

namespace DungeonGeneration {
    [CreateAssetMenu(fileName = "SimpleRandomWalkParameters_", menuName = "PCG/SimpleRadnomWalkData")]
    public class SimpleRandomWalkSO : ScriptableObject {
        public int iterations = 10, walkLength = 10;
        [Tooltip("If True, the Dungeon Will more Expand, else the Starting Point will get more Covered")] [SerializeField]
        public bool startRandomlyEachIteration = true;
    }
}