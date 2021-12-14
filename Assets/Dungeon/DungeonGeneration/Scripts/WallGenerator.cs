using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    public static class WallGenerator
    {
        public static List<DungeonWall> CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
        {
            var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionList);
            var cornerWallPositions = FindWallsInDirections(floorPositions, Direction2D.diagonalDirectionsList);
            List<DungeonWall> dungeonWalls = CreateBasicWall(tilemapVisualizer, basicWallPositions, floorPositions);
            List<DungeonWall> walls = CreateCornerWalls(tilemapVisualizer, cornerWallPositions, floorPositions);
            dungeonWalls.AddRange(walls);
            foreach (var dungeonWall in dungeonWalls)
            {
                dungeonWall.Draw(tilemapVisualizer);
            }
            return dungeonWalls;
        }

        private static List<DungeonWall> CreateCornerWalls(TilemapVisualizer tilemapVisualizer,
            HashSet<Vector2Int> cornerWallPositions, HashSet<Vector2Int> floorPositions)
        {
            List<DungeonWall> dungeonWalls = new List<DungeonWall>();

            foreach (var position in cornerWallPositions)
            {
                string neighboursBinaryType = "";
                foreach (var direction in Direction2D.eightDirectionsList)
                {
                    var neighbourPosition = position + direction;
                    if (floorPositions.Contains(neighbourPosition))
                    {
                        neighboursBinaryType += "1";
                    }
                    else
                    {
                        neighboursBinaryType += "0";
                    }
                }
                dungeonWalls.Add(new DungeonWall(position,neighboursBinaryType, true ));

                tilemapVisualizer.PaintSingleCornerWall(position, neighboursBinaryType);
            }
            return dungeonWalls;
        }

        private static List<DungeonWall> CreateBasicWall(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> basicWallPositions,
            HashSet<Vector2Int> floorPositions)
        {
            List<DungeonWall> dungeonWalls = new List<DungeonWall>();
            foreach (var position in basicWallPositions)
            {
                string neighboursBinaryType = "";
                foreach (var direction in Direction2D.cardinalDirectionList)
                {
                    var neighbourPosition = position + direction;
                    if (floorPositions.Contains(neighbourPosition))
                    {
                        neighboursBinaryType += "1";
                    }
                    else
                    {
                        neighboursBinaryType += "0";
                    }
                }
                dungeonWalls.Add(new DungeonWall(position,neighboursBinaryType ));

                tilemapVisualizer.PaintSingleBasicWall(position, neighboursBinaryType);
            }
            return dungeonWalls;
        }

        private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions,
            List<Vector2Int> directionList)
        {
            HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
            foreach (var position in floorPositions)
            {
                foreach (var direction in directionList)
                {
                    var neighbourPosition = position + direction;
                    if (floorPositions.Contains(neighbourPosition) == false)
                        wallPositions.Add(neighbourPosition);
                }
            }

            return wallPositions;
        }
    }
}