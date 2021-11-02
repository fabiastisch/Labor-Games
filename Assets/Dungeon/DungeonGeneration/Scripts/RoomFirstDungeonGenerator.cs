using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Dungeon.DungeonGeneration
{
    public class RoomFirstDungeonGenerator : SimpleRandomWalkDungeonGenerator
    {
        private RoomFirstDungeonGeneratorSo parameters;

        public RoomFirstDungeonGenerator(RoomFirstDungeonGeneratorSo parameter, DungeonGenerator generator) : base(
            parameter, generator)
        {
            this.parameters = parameter;
        }

        public override void RunProceduralGeneration()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {
            var roomsList = ProceduralGenerationAlgorithms.BinarySpacePartitioning(new BoundsInt(
                    (Vector3Int) parameters.startPosition,
                    new Vector3Int(parameters.dungeonWidth, parameters.dungeonHeight, 0)), parameters.minRoomWidth,
                parameters.minRoomHeight);
            HashSet<Vector2Int> floor;


            var last = roomsList.Last();
            if (generator.currentPortal)
            {
                generator.currentPortal.transform.position = last.center;
            }
            else
            {
                //_portal = Instantiate(portal, last.center, Quaternion.identity, gameObject.transform);
                generator.currentPortal = generator.portal;
                generator.currentPortal.transform.position = last.center;
            }

            var first = roomsList.First();
            if (generator.currentSpawn)
            {
                generator.currentSpawn.transform.position = first.center;
            }
            else
            {
                //_spawn = Instantiate(spawn, first.center, Quaternion.identity, gameObject.transform);
                generator.currentSpawn = generator.spawn;
                generator.currentSpawn.transform.position = first.center;
            }

            CreateTrapRooms(roomsList);

            HashSet<Vector2Int> bonusRoom = CreateBonusRoom(roomsList);


            if (parameters.randomWalkRooms)
            {
                floor = CreateRoomsRandomly(roomsList);
            }
            else
            {
                floor = CreateSimpleRooms(roomsList, parameters.dungeonOffset);
            }

            HashSet<Vector2Int> corridors = ConnectRooms(roomsList);
            floor.UnionWith(corridors);
            CreateCorridorTraps(corridors, floor);

            generator.tilemapVisualizer.PaintFloorTiles(floor);
            WallGenerator.CreateWalls(floor, generator.tilemapVisualizer);

            if (bonusRoom != null) floor.UnionWith(bonusRoom);

            WallGenerator.CreateWalls(floor, generator.bonusRoomTileMapVis);
        }

        private HashSet<Vector2Int> CreateBonusRoom(List<BoundsInt> roomsList)
        {
            int countOfBonusRoom = Util.GetChance(parameters.bonusRoomChance);
            if (countOfBonusRoom == 0) return null;

            /*List<Vector2Int> roomCenters = new List<Vector2Int>();
            foreach (var room in roomsList)
            {
                roomCenters.Add((Vector2Int) Vector3Int.RoundToInt(room.center));
            }*/

            int counter = 1, index = 0;
            Vector2Int pos = Vector2Int.zero;
            Vector2Int closestRoom = Vector2Int.zero;
            var dir = parameters.direction;
            if (parameters.direction == Dir.Random)
            {
                var array = Enum.GetValues(typeof(Dir));
                dir = (Dir) array.GetValue(Random.Range(0, array.Length - 1));
            }

            switch (dir)
            {
                case Dir.LEFT:
                    roomsList.Sort((one, two) => one.xMin.CompareTo(two.xMin));
                    int xMin = roomsList[0].xMin;
                    for (int i = 1; i < roomsList.Count; i++)
                    {
                        if (roomsList[i].xMin < xMin + parameters.minRoomWidth)
                        {
                            counter++;
                        }
                    }


                    //index = Random.Range(0, counter + 1);
                    closestRoom = new Vector2Int((int) roomsList[index].center.x, (int) roomsList[index].center.y);
                    pos = new Vector2Int(
                        roomsList[index].xMin - (parameters.bonusRoomOffset + parameters.bonusRoomWidth),
                        (int) roomsList[index].y);

                    break;
                case Dir.RIGHT:
                    roomsList.Sort((one, two) => two.xMax.CompareTo(one.xMax));
                    int xMax = roomsList[0].xMax;
                    for (int i = 1; i < roomsList.Count; i++)
                    {
                        if (roomsList[i].xMax > xMax - parameters.minRoomWidth)
                        {
                            counter++;
                        }
                    }

                    //index = Random.Range(0, counter + 1);
                    closestRoom = new Vector2Int((int) roomsList[index].center.x, (int) roomsList[index].center.y);

                    pos = new Vector2Int(roomsList[index].xMax + (parameters.bonusRoomOffset),
                        (int) roomsList[index].yMin);


                    break;
                case Dir.DOWN:
                    roomsList.Sort((one, two) => one.yMin.CompareTo(two.yMin));
                    int yMin = roomsList[0].xMax;
                    for (int i = 1; i < roomsList.Count; i++)
                    {
                        if (roomsList[i].xMax < yMin + parameters.minRoomHeight)
                        {
                            counter++;
                        }
                    }

                    //index = Random.Range(0, counter + 1);
                    closestRoom = new Vector2Int((int) roomsList[index].center.x, (int) roomsList[index].center.y);

                    pos = new Vector2Int((int) roomsList[index].center.x - parameters.bonusRoomWidth / 2,
                        roomsList[index].yMin - (parameters.bonusRoomOffset + parameters.bonusRoomHeight));

                    break;
                case Dir.UP:
                    roomsList.Sort((one, two) => two.yMax.CompareTo(one.yMax));
                    int yMax = roomsList[0].xMax;
                    for (int i = 1; i < roomsList.Count; i++)
                    {
                        if (roomsList[i].xMax > yMax - parameters.minRoomHeight)
                        {
                            counter++;
                        }
                    }

                    //index = Random.Range(0, counter + 1);
                    closestRoom = new Vector2Int((int) roomsList[index].center.x, (int) roomsList[index].center.y);
                    pos = new Vector2Int((int) roomsList[index].center.x - parameters.bonusRoomWidth / 2,
                        roomsList[index].yMax + (parameters.bonusRoomOffset));

                    break;
            }

            var bonusRoom = new BoundsInt(new Vector3Int(pos.x, pos.y, 0),
                new Vector3Int(parameters.bonusRoomWidth, parameters.bonusRoomHeight, 0));

            var bonusRoomPositions = CreateSimpleRooms(new List<BoundsInt> {bonusRoom});

            var bonusRoomCorridor =
                CreateCorridor(closestRoom,
                    pos + new Vector2Int(parameters.bonusRoomWidth / 2, parameters.bonusRoomHeight / 2));

            bonusRoomPositions.UnionWith(bonusRoomCorridor);

            generator.bonusRoomTileMapVis.PaintFloorTiles(bonusRoomPositions);
            //WallGenerator.CreateWalls(bonusRoomPositions, bonusRoomTileMapVis);
            return bonusRoomPositions;
        }

        private void CreateTrapRooms(List<BoundsInt> roomList)
        {
            int countOfTrapRooms = Util.GetChance(parameters.trapRoomChance);
            if (countOfTrapRooms < 1) return;
            HashSet<int> usedIndexes = new HashSet<int>();
            for (int i = 0; i < countOfTrapRooms; i++)
            {
                int index = 0;
                do
                {
                    index = Random.Range(1, roomList.Count);
                } while (usedIndexes.Contains(index));

                usedIndexes.Add(index);
                var room = roomList[index];
                generator.Instantiate(generator.trapRoom, room.center);

                //generator.traps.Add(Instantiate(generator.trapRoom, room.center, Quaternion.identity, generator.gameObject.transform));
            }
        }

        private HashSet<Vector2Int> CreateRoomsRandomly(List<BoundsInt> roomsList)
        {
            HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
            foreach (var roomBounds in roomsList)
            {
                var roomCenter = new Vector2Int(Mathf.RoundToInt(roomBounds.center.x),
                    Mathf.RoundToInt(roomBounds.center.y));
                var roomFloor = RunRandomWalk(roomCenter);
                foreach (var position in roomFloor)
                {
                    if (position.x >= (roomBounds.xMin + parameters.dungeonOffset) &&
                        position.x <= (roomBounds.xMax - parameters.dungeonOffset) &&
                        position.y >= (roomBounds.yMin - parameters.dungeonOffset) &&
                        position.y <= (roomBounds.yMax - parameters.dungeonOffset))
                    {
                        floor.Add(position);
                    }
                }
            }

            return floor;
        }

        private HashSet<Vector2Int> ConnectRooms(List<BoundsInt> roomsList)
        {
            List<Vector2Int> roomCenters = new List<Vector2Int>();
            foreach (var room in roomsList)
            {
                roomCenters.Add((Vector2Int) Vector3Int.RoundToInt(room.center));
            }

            HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
            var currentRoomCenter = roomCenters[Random.Range(0, roomCenters.Count)];
            roomCenters.Remove(currentRoomCenter);

            while (roomCenters.Count > 0)
            {
                Vector2Int closest = FindClosestPointTo(currentRoomCenter, roomCenters);
                roomCenters.Remove(closest);
                HashSet<Vector2Int> newCorridor = CreateCorridor(currentRoomCenter, closest);
                currentRoomCenter = closest;
                corridors.UnionWith(newCorridor);
            }

            return corridors;
        }

        private Vector2Int FindClosestPointTo(Vector2Int currentRoomCenter, List<Vector2Int> roomCenters)
        {
            Vector2Int closest = Vector2Int.zero;
            float length = float.MaxValue;
            foreach (var position in roomCenters)
            {
                float currentDist = Vector2.Distance(position, currentRoomCenter);
                if (currentDist < length)
                {
                    length = currentDist;
                    closest = position;
                }
            }

            return closest;
        }

        private HashSet<Vector2Int> CreateCorridor(Vector2Int currentRoomCenter, Vector2Int destination)
        {
            HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
            var position = currentRoomCenter;


            for (int i =
                    -(parameters.corridorWidth % 2 == 0 ? parameters.corridorWidth : parameters.corridorWidth + 1) / 2;
                i < parameters.corridorWidth / 2;
                i++)
            {
                corridor.Add(position + Vector2Int.right * i);
            }

            for (int i =
                    -(parameters.corridorWidth % 2 == 0 ? parameters.corridorWidth : parameters.corridorWidth + 1) / 2;
                i < parameters.corridorWidth / 2;
                i++)
            {
                corridor.Add(position + Vector2Int.down * i);
            }

            while (position.y != destination.y)
            {
                if (destination.y > position.y)
                {
                    position += Vector2Int.up;
                }
                else if (destination.y < position.y)
                {
                    position += Vector2Int.down;
                }

                for (int i = -(parameters.corridorWidth % 2 == 0
                        ? parameters.corridorWidth
                        : parameters.corridorWidth + 1) / 2;
                    i < parameters.corridorWidth / 2;
                    i++)
                {
                    corridor.Add(position + Vector2Int.right * i);
                }
            }

            for (int i =
                    -(parameters.corridorWidth % 2 == 0 ? parameters.corridorWidth : parameters.corridorWidth + 1) / 2;
                i < parameters.corridorWidth / 2;
                i++)
            {
                corridor.Add(position + Vector2Int.down * i);
            }

            while (position.x != destination.x)
            {
                if (destination.x > position.x)
                {
                    position += Vector2Int.right;
                }
                else if (destination.x < position.x)
                {
                    position += Vector2Int.left;
                }

                for (int i = -(parameters.corridorWidth % 2 == 0
                        ? parameters.corridorWidth
                        : parameters.corridorWidth + 1) / 2;
                    i < parameters.corridorWidth / 2;
                    i++)
                {
                    corridor.Add(position + Vector2Int.down * i);
                }
            }

            return corridor;
        }

        private void CreateCorridorTraps(HashSet<Vector2Int> corridor, HashSet<Vector2Int> floorsWithCorridor)
        {
            // TODO: Fix Corridor Traps -- Directions and add trap prefab 
            int countOfCorridorTraps = Util.GetChance(parameters.corridorTrapChance);
            if (countOfCorridorTraps == 0) return;

            List<Wall> wallPositions = new List<Wall>();
            // loop through each corridor position
            foreach (var position in corridor)
            {
                for (int i = 0; i < Direction2D.cardinalDirectionList.Count; i++)
                {
                    var neighbourPosition = position + Direction2D.cardinalDirectionList[i];
                    // check if the neighbour is at floor
                    if (floorsWithCorridor.Contains(neighbourPosition) == false)
                    {
                        // if its not, then its a wall
                        wallPositions.Add(new Wall(position,
                            (Direction) Enum.GetValues(typeof(Direction)).GetValue(i)));
                    }
                }
            }

            var selectedCorridorWalls =
                wallPositions.FindAll(x => x.facingTowards == parameters.corridorTrapSpawnDirection);
            if (parameters.corridorTrapSpawnDirection == Direction.UP ||
                parameters.corridorTrapSpawnDirection == Direction.DOWN)
            {
                // Reverse sorting, first x, then y
                selectedCorridorWalls.Sort((first, second) => first.position.x.CompareTo(second.position.x));
                selectedCorridorWalls = new List<Wall>(selectedCorridorWalls.OrderBy(wall => wall.position.y));
            }
            else
            {
                // Sort first by y then by x. make sure that the Second sort is stalbe
                selectedCorridorWalls.Sort((first, second) => first.position.y.CompareTo(second.position.y));
                // Order By is Stable Sort
                selectedCorridorWalls = new List<Wall>(selectedCorridorWalls.OrderBy(wall => wall.position.x));
            }

            if (selectedCorridorWalls.Count <= 3) return;
            
            
            if (parameters.corridorTrapSpawnDirection == Direction.UP ||
                parameters.corridorTrapSpawnDirection == Direction.DOWN)
            {
                //var findAll = selectedCorridorPositions.FindAll(x => x.position.y == start.position.y);
                //var findAll = selectedCorridorPositions;
                /*foreach (var wall in findAll)
                {
                    Debug.Log(wall.position);
                }*/

                for (var i = 0; i < selectedCorridorWalls.Count; i++)
                {
                    var wall = selectedCorridorWalls[i];
                    var countOffset = 0;

                    do
                    {
                        countOffset++;
                    } while ((i + countOffset < selectedCorridorWalls.Count) &&
                             wall.position.x == selectedCorridorWalls[i + countOffset].position.x - countOffset
                    );

                    //Debug.Log(i + " | " + countOffset + " size: " + findAll.Count);

                    for (int j = 0; j < countOffset; j++)
                    {
                        //Debug.Log(findAll[i + j] + " " + i + " | " + j + " size: " + findAll.Count);
                        var position = new Vector3(selectedCorridorWalls[i + j].position.x, selectedCorridorWalls[i + j].position.y);
                        generator.Instantiate(generator.trapRoom.transform.GetChild(0).gameObject, position);

                    }

                    i += (countOffset - 1);
                }
            }
            else
            {
                //var findAll = selectedCorridorPositions.FindAll(x => x.position.x == start.position.x);
                //var findAll = selectedCorridorPositions;
                /*foreach (var wall in findAll)
                {
                    Debug.Log(wall.position);
                }*/

                for (var i = 0; i < selectedCorridorWalls.Count; i++)
                {
                    var wall = selectedCorridorWalls[i];
                    var countOffset = 0;

                    do
                    {
                        countOffset++;
                    } while ((i + countOffset < selectedCorridorWalls.Count) &&
                             wall.position.y == selectedCorridorWalls[i + countOffset].position.y - countOffset
                    );

                    //Debug.Log(i + " | " + countOffset + " size: " + findAll.Count);

                    for (int j = 0; j < countOffset; j++)
                    {
                        //Debug.Log(findAll[i + j] + " " + i + " | " + j + " size: " + findAll.Count);
                        var position = new Vector3(selectedCorridorWalls[i + j].position.x, selectedCorridorWalls[i + j].position.y);
                        generator.Instantiate(generator.trapRoom.transform.GetChild(0).gameObject, position);
                    }

                    i += (countOffset - 1);
                }
            }
        }

        private HashSet<Vector2Int> CreateSimpleRooms(List<BoundsInt> roomsList, int offset = 0)
        {
            HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
            foreach (var room in roomsList)
            {
                for (int col = offset; col < room.size.x - offset; col++)
                {
                    for (int row = offset; row < room.size.y - offset; row++)
                    {
                        Vector2Int position = (Vector2Int) room.min + new Vector2Int(col, row);
                        floor.Add(position);
                    }
                }
            }

            return floor;
        }
    }

    public enum Dir
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        Random
    }
}