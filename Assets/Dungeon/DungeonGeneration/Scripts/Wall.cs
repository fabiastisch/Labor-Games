using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    public struct Wall
    {
        public Vector2Int position;
        public Direction facingTowards;

        public Wall(Vector2Int position, Direction facingTowards)
        {
            this.position = position;
            this.facingTowards = facingTowards;
        }
    }
}