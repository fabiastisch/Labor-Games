using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Dungeon.DungeonGeneration
{
    public class TilemapVisualizer : MonoBehaviour
    {
        [SerializeField] public Tilemap floorTilemap, wallTileMap;

        private DungeonTilesSo tiles;
        private bool tilesSet = false;

        private void Awake()
        {
            SetTiles();
        }

        private void Start()
        {
            float val = 20 / 255f;
            Color32 c = new Color(val,val,val);
            
            if (Camera.main != null)
                Camera.main.backgroundColor = c.Multiply(wallTileMap.color);
        }

        private void SetTiles()
        {
            DungeonTilesSo dungeonTiles = GetComponentInParent<DungeonGenerator>().dungeonTiles;
            tiles = dungeonTiles;
            tilesSet = dungeonTiles != null;
        }

        public void SetColor(Color? floorColor, Color? wallColor)
        {
            if (floorColor != null) floorTilemap.color = (Color) floorColor;
            if (wallColor != null) wallTileMap.color = (Color) wallColor;
        }

        public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
        {
            if (!tilesSet) SetTiles();
            PaintTiles(floorPositions, floorTilemap, tiles.floorTiles);
        }
        private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, List<TileBase> tiles)
        {
            foreach (var position in positions)
            {
                PaintSingleTile(tilemap, tiles[Utils.Util.GetRandomInt(tiles.Count - 1)], position);
            }
        }

        private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
        {
            foreach (var position in positions)
            {
                PaintSingleTile(tilemap, tile, position);
            }
        }

        internal void PaintSingleBasicWall(Vector2Int position, string binaryType)
        {
            if (!tilesSet) SetTiles();
            int typeAsInt = Convert.ToInt32(binaryType, 2);
            TileBase tile = null;
            if (WallTypesHelper.wallTop.Contains(typeAsInt))
            {
                tile = tiles.wallTop;
            }
            else if (WallTypesHelper.wallSideRight.Contains(typeAsInt))
            {
                tile = tiles.wallSideRight;
            }
            else if (WallTypesHelper.wallSideLeft.Contains(typeAsInt))
            {
                tile = tiles.wallSideLeft;
            }
            else if (WallTypesHelper.wallBottom.Contains(typeAsInt))
            {
                tile = tiles.wallBottom;
            }
            else if (WallTypesHelper.wallFull.Contains(typeAsInt))
            {
                tile = tiles.wallFull;
            }

            if (tile != null)
                PaintSingleTile(wallTileMap, tile, position);
        }

        private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
        {
            var tilePosition = tilemap.WorldToCell((Vector3Int) position);
            tilemap.SetTile(tilePosition, tile);
        }

        public void Clear()
        {
            floorTilemap.ClearAllTiles();
            wallTileMap.ClearAllTiles();
        }

        internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
        {
            if (!tilesSet) SetTiles();
            int typeAsInt = Convert.ToInt32(binaryType, 2);
            TileBase tile = null;

            if (WallTypesHelper.wallInnerCornerDownLeft.Contains(typeAsInt))
            {
                tile = tiles.wallInnerCornerDownLeft;
            }
            else if (WallTypesHelper.wallInnerCornerDownRight.Contains(typeAsInt))
            {
                tile = tiles.wallInnerCornerDownRight;
            }
            else if (WallTypesHelper.wallDiagonalCornerDownLeft.Contains(typeAsInt))
            {
                tile = tiles.wallDiagonalCornerDownLeft;
            }
            else if (WallTypesHelper.wallDiagonalCornerDownRight.Contains(typeAsInt))
            {
                tile = tiles.wallDiagonalCornerDownRight;
            }
            else if (WallTypesHelper.wallDiagonalCornerUpRight.Contains(typeAsInt))
            {
                tile = tiles.wallDiagonalCornerUpRight;
            }
            else if (WallTypesHelper.wallDiagonalCornerUpLeft.Contains(typeAsInt))
            {
                tile = tiles.wallDiagonalCornerUpLeft;
            }
            else if (WallTypesHelper.wallFullEightDirections.Contains(typeAsInt))
            {
                tile = tiles.wallFull;
            }
            else if (WallTypesHelper.wallBottomEightDirections.Contains(typeAsInt))
            {
                tile = tiles.wallBottom;
            }

            if (tile != null)
                PaintSingleTile(wallTileMap, tile, position);
        }

        public void DrawWall(Vector2Int position, DungeonWallTypes? type)
        {
            TileBase tile = null;

            switch (type)
            {
                case DungeonWallTypes.wallBottom:
                    tile = tiles.wallBottom;
                    break;
                case DungeonWallTypes.wallFull:
                    tile = tiles.wallFull;
                    break;
                case DungeonWallTypes.wallTop:
                    tile = tiles.wallTop;
                    break;
                case DungeonWallTypes.wallSideLeft:
                    tile = tiles.wallSideLeft;
                    break;
                case DungeonWallTypes.wallSideRight:
                    tile = tiles.wallSideRight;
                    break;
                case DungeonWallTypes.wallBottomEightDirections:
                    tile = tiles.wallBottom;
                    break;
                case DungeonWallTypes.wallFullEightDirections:
                    tile = tiles.wallFull;
                    break;
                case DungeonWallTypes.wallDiagonalCornerDownLeft:
                    tile = tiles.wallDiagonalCornerDownLeft;
                    break;
                case DungeonWallTypes.wallDiagonalCornerDownRight:
                    tile = tiles.wallDiagonalCornerDownRight;
                    break;
                case DungeonWallTypes.wallDiagonalCornerUpLeft:
                    tile = tiles.wallDiagonalCornerUpLeft;
                    break;
                case DungeonWallTypes.wallDiagonalCornerUpRight:
                    tile = tiles.wallDiagonalCornerUpRight;
                    break;
                case DungeonWallTypes.wallInnerCornerDownLeft:
                    tile = tiles.wallInnerCornerDownLeft;
                    break;
                case DungeonWallTypes.wallInnerCornerDownRight:
                    tile = tiles.wallInnerCornerDownRight;
                    break;
            }
            if (tile != null)
                PaintSingleTile(wallTileMap, tile, position);
        }
    }
}