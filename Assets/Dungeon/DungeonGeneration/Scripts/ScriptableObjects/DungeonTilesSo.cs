using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Dungeon.DungeonGeneration
{
    [CreateAssetMenu(fileName = "DungeonTiles_", menuName = "PCG/Tiles")]
    public class DungeonTilesSo : ScriptableObject
    {
        [Header("Tiles")] public TileBase floorTile;
        public List<TileBase> floorTiles = new List<TileBase>();

        [Header("Walls")]
        public TileBase
            wallTop;
        public TileBase
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