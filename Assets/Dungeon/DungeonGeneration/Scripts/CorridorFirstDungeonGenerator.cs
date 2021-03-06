using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    public class CorridorFirstDungeonGenerator : SimpleRandomWalkDungeonGenerator
    {
        private CorridorFirstDungeonGeneratorSo parameters;

        public CorridorFirstDungeonGenerator(CorridorFirstDungeonGeneratorSo parameter, DungeonGenerator generator) : base(
            parameter, generator)
        {
            this.parameters = parameter;
        }

        public override void RunProceduralGeneration()
        {
            CorridorFirstDungeonGeneration();
        }

        private void CorridorFirstDungeonGeneration()
        {
            HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
            HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();
            CreateCorridors(floorPositions, potentialRoomPositions);

            HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);

            List<Vector2Int> deadEnds = FindAllDeadEnds(floorPositions);
            CreateRoomsAdDeadEnds(deadEnds, roomPositions);

            floorPositions.UnionWith(roomPositions);

            generator.tilemapVisualizer.PaintFloorTiles(floorPositions);
            WallGenerator.CreateWalls(floorPositions, generator.tilemapVisualizer);
        }

        private void CreateRoomsAdDeadEnds(List<Vector2Int> deadEnds, HashSet<Vector2Int> roomFloors)
        {
            foreach (var position in deadEnds)
            {
                if (!roomFloors.Contains(position))
                {
                    var room = RunRandomWalk(position);
                    roomFloors.UnionWith(room);
                }
            }
        }

        private List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floorPositions)
        {
            List<Vector2Int> deadEnds = new List<Vector2Int>();
            foreach (var position in floorPositions)
            {
                int neighboursCount = 0;
                foreach (var direction in Direction2D.cardinalDirectionList)
                {
                    if (floorPositions.Contains(position + direction))
                    {
                        neighboursCount++;
                    }
                }

                if (neighboursCount == 1)
                {
                    deadEnds.Add(position);
                }
            }

            return deadEnds;
        }

        private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions)
        {
            HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();
            int roomToCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * parameters.roomPercent);
            List<Vector2Int> roomsToCreate =
                potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomToCreateCount).ToList();
            foreach (var roomPos in roomsToCreate)
            {
                var roomFloor = RunRandomWalk(roomPos);
                roomPositions.UnionWith(roomFloor);
            }

            return roomPositions;
        }

        private void CreateCorridors(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> potentialRoomPositions)
        {
            var currentPosition = parameters.startPosition;
            potentialRoomPositions.Add(currentPosition);
            for (int i = 0; i < parameters.corridorCount; i++)
            {
                var corridor =
                    ProceduralGenerationAlgorithms.RandomWalkCorridor(currentPosition, parameters.corridorLength);
                currentPosition = corridor[corridor.Count - 1];
                potentialRoomPositions.Add(currentPosition);
                floorPositions.UnionWith(corridor);
            }
        }
    }
}