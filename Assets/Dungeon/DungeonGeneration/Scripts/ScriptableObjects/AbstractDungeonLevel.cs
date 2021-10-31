using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "AbstractDungeonLevel_", menuName = "PCG/AbstractDungeonLevel")]
    public class AbstractDungeonLevel : ScriptableObject
    {
        public IEnumerable<Vector2Int> floorPositions;
    }
}