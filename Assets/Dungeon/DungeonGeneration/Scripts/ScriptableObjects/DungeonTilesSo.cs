using UnityEngine;
using UnityEngine.Tilemaps;

namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "DungeonTiles_", menuName = "PCG/Tiles")]
    public class DungeonTilesSo : ScriptableObject
    {
        [Header("Tiles")] public TileBase floorTile;

        public TileBase
            wallTop,
            wallSideRight,
            wallSideLeft,
            wallBottom,
            wallFull,
            wallInnerCornerDownLeft,
            wallInnerCornerDownRight,
            wallDiagonalCornerDownRight,
            wallDiagonalCornerDownLeft,
            wallDiagonalCornerUpRight,
            wallDiagonalCornerUpLeft;
    }
}