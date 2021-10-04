using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DungeonGeneration {
    public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator {
        [SerializeField] protected int iterations = 10;
        [SerializeField] protected  int walkLength = 10;

        [Tooltip("If True, the Dungeon Will more Expand, else the Starting Point will get more Covered")] [SerializeField]
        protected bool startRandomlyEachIteration = true;


        protected override void RunProceduralGeneration() {
            HashSet<Vector2Int> floorPos = RunRandomWalk(startPosition);
            tilemapVisualizer.PaintFloorTiles(floorPos);
            WallGenerator.CreateWalls(floorPos, tilemapVisualizer);
        }

        protected HashSet<Vector2Int> RunRandomWalk(Vector2Int position) {
            var currentPos = position;
            HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
            for (int i = 0; i < iterations; i++) {
                var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPos, walkLength);
                floorPos.UnionWith(path);
                if (startRandomlyEachIteration) {
                    currentPos = floorPos.ElementAt(Random.Range(0, floorPos.Count));
                }
            }

            return floorPos;
        }
    }
}