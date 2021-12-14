using System;
using UnityEngine;
namespace Dungeon.DungeonGeneration
{
    public class DungeonWall
    {
        public readonly Vector2Int _vector2Int;
        private readonly string _neighboursBinaryType;
        public DungeonWallTypes? type;
        public DungeonWall(Vector2Int vector2Int, string neighboursBinaryType, bool isCorner = false)
        {
            _vector2Int = vector2Int;
            _neighboursBinaryType = neighboursBinaryType;
            this.type = GetDungeonTypeWall(isCorner);

        }

        private DungeonWallTypes? GetDungeonTypeWall(bool isCorner)
        {
            int typeAsInt = Convert.ToInt32(_neighboursBinaryType, 2);
            if (isCorner)
            {
                return GetCornerType(typeAsInt);
            }
            if (WallTypesHelper.wallTop.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallTop;
            }
            else if (WallTypesHelper.wallSideRight.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallSideRight;
            }
            else if (WallTypesHelper.wallSideLeft.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallSideLeft;
            }
            else if (WallTypesHelper.wallBottom.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallBottom;
            }
            else if (WallTypesHelper.wallFull.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallFull;
            }
            
            return null;
        }
        private DungeonWallTypes? GetCornerType(int typeAsInt)
        {
            if (WallTypesHelper.wallInnerCornerDownLeft.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallInnerCornerDownLeft;
            }
            else if (WallTypesHelper.wallInnerCornerDownRight.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallInnerCornerDownRight;
            }
            else if (WallTypesHelper.wallDiagonalCornerDownLeft.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallDiagonalCornerDownLeft;
            }
            else if (WallTypesHelper.wallDiagonalCornerDownRight.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallDiagonalCornerDownRight;
            }
            else if (WallTypesHelper.wallDiagonalCornerUpRight.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallDiagonalCornerUpRight;
            }
            else if (WallTypesHelper.wallDiagonalCornerUpLeft.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallDiagonalCornerUpLeft;
            }
            else if (WallTypesHelper.wallFullEightDirections.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallFullEightDirections;
            }
            else if (WallTypesHelper.wallBottomEightDirections.Contains(typeAsInt))
            {
                return DungeonWallTypes.wallBottomEightDirections;
            }
            return null;
        }

        public void Draw(TilemapVisualizer tilemapVisualizer)
        {
                tilemapVisualizer.DrawWall(_vector2Int, type);
        }
    }

    public enum DungeonWallTypes
    {
        wallTop,
        wallSideLeft,
        wallSideRight,
        wallBottom,
        wallInnerCornerDownLeft,
        wallInnerCornerDownRight,
        wallDiagonalCornerDownLeft,
        wallDiagonalCornerDownRight,
        wallDiagonalCornerUpLeft,
        wallDiagonalCornerUpRight,
        wallFull,
        wallFullEightDirections,
        wallBottomEightDirections
    }
}