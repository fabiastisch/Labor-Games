using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGeneratorNew
    {
        
        public SimpleRandomWalkDungeonGenerator(DungeonGeneratorParameterSo parameter, DungeonGenerator generator) : base(parameter, generator)
        {
        }

        protected override void RunProceduralGeneration()
        {
            HashSet<Vector2Int> floorPos = RunRandomWalk(parameters.startPosition);
            generator.tilemapVisualizer.PaintFloorTiles(floorPos);
            WallGenerator.CreateWalls(floorPos, generator.tilemapVisualizer);
        }

        protected HashSet<Vector2Int> RunRandomWalk(Vector2Int position)
        {
            var currentPos = position;
            HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
            for (int i = 0; i < parameters.iterations; i++)
            {
                var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPos, parameters.walkLength);
                floorPos.UnionWith(path);
                if (parameters.startRandomlyEachIteration)
                {
                    currentPos = floorPos.ElementAt(Random.Range(0, floorPos.Count));
                }
            }

            return floorPos;
        }
    }
}