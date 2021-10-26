using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    public class RoomDungeonGenerator : AbstractDungeonGeneratorNew
    {
        private RoomDungeonGeneratorSo parameters;

        public RoomDungeonGenerator(RoomDungeonGeneratorSo parameters,
            DungeonGenerator generator) : base(parameters, generator)
        {
            this.parameters = parameters;
        }

        public override void RunProceduralGeneration()
        {
            HashSet<Vector2Int> floors = new HashSet<Vector2Int>();

            if (parameters.createRectangularRoom)
            {
                floors = CreateRectangularRoom();
            }

            if (parameters.createRoundRoom)
            {
                floors.UnionWith(CreateRoundRoom());
            }

            if (!generator.currentPortal)
            {
                generator.currentPortal = generator.portal;
            }

            generator.currentPortal.transform.position = Vector2.one;

            if (!generator.currentSpawn)
            {
                generator.currentSpawn = generator.spawn;
            }

            generator.currentSpawn.transform.position = Vector2.zero;

            generator.tilemapVisualizer.PaintFloorTiles(floors);
            WallGenerator.CreateWalls(floors, generator.tilemapVisualizer);
        }

        private HashSet<Vector2Int> CreateRoundRoom()
        {
            HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
            for (int i = (int) -parameters.radius; i <= parameters.radius; i++)
            {
                for (int j = (int) -parameters.radius; j <= parameters.radius; j++)
                {
                    var position = new Vector2Int(i, j);
                    if (Vector2.Distance(position, parameters.startPosition) <= parameters.radius)
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
            for (int i = 0; i < parameters.height; i++)
            {
                for (int j = 0; j < parameters.with; j++)
                {
                    Vector2Int position = parameters.startPosition + new Vector2Int(i, j);
                    floor.Add(position);
                }
            }

            return floor;
        }
    }
}