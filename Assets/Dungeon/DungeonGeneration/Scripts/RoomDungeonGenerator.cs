using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    public class RoomDungeonGenerator : AbstractDungeonGenerator
    {
        [SerializeField] private RoomDungeonGeneratorSo _roomDungeonGeneratorSo;


        protected override void RunProceduralGeneration()
        {
            HashSet<Vector2Int> floors = new HashSet<Vector2Int>();

            if (_roomDungeonGeneratorSo.createRectangularRoom)
            {
                floors = CreateRectangularRoom();
            }

            if (_roomDungeonGeneratorSo.createRoundRoom)
            {
                floors.UnionWith(CreateRoundRoom());
            }

            tilemapVisualizer.PaintFloorTiles(floors);
            WallGenerator.CreateWalls(floors, tilemapVisualizer);
        }

        private HashSet<Vector2Int> CreateRoundRoom()
        {
            HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
            for (int i = (int) -_roomDungeonGeneratorSo.radius; i <= _roomDungeonGeneratorSo.radius; i++)
            {
                for (int j = (int) -_roomDungeonGeneratorSo.radius; j <= _roomDungeonGeneratorSo.radius; j++)
                {
                    var position = new Vector2Int(i, j);
                    if (Vector2.Distance(position, startPosition) <= _roomDungeonGeneratorSo.radius)
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
            for (int i = 0; i < _roomDungeonGeneratorSo.height; i++)
            {
                for (int j = 0; j < _roomDungeonGeneratorSo.with; j++)
                {
                    Vector2Int position = startPosition + new Vector2Int(i, j);
                    floor.Add(position);
                }
            }

            return floor;
        }
    }
}