using System.Collections.Generic;
using UnityEngine;

namespace DungeonGeneration.Scripts
{
    public class RoomDungeonGenerator : AbstractDungeonGenerator
    {
        [Header("Rectangular Room")] [SerializeField]
        private bool createRectangularRoom;

        [SerializeField] private int with = 14;
        [SerializeField] private int height = 14;

        [Header("Round Room")] [SerializeField]
        private bool createRoundRoom;

        [SerializeField] private float radius = 10;


        protected override void RunProceduralGeneration()
        {
            HashSet<Vector2Int> floors = new HashSet<Vector2Int>();

            if (createRectangularRoom)
            {
                floors = CreateRectangularRoom();
            }

            if (createRoundRoom)
            {
                floors.UnionWith(CreateRoundRoom());
            }

            tilemapVisualizer.PaintFloorTiles(floors);
            WallGenerator.CreateWalls(floors, tilemapVisualizer);
        }

        private HashSet<Vector2Int> CreateRoundRoom()
        {
            HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
            for (int i = (int) -radius; i <= radius; i++)
            {
                for (int j = (int) -radius; j <= radius; j++)
                {
                    var position = new Vector2Int(i, j);
                    if (Vector2.Distance(position, startPosition) <= radius)
                    {
                        floor.Add(position);
                    }
                }
            }

            return floor;
        }

        private HashSet<Vector2Int> CreateRectangularRoom()
        {
            HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < with; j++)
                {
                    Vector2Int position = startPosition + new Vector2Int(i, j);
                    floor.Add(position);
                }
            }

            return floor;
        }
    }
}