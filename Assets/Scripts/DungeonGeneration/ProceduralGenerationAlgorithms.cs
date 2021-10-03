﻿using System.Collections.Generic;
using UnityEngine;

namespace DungeonGeneration {
    public static class ProceduralGenerationAlgorithms {
        public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPos, int walkLength) {
            HashSet<Vector2Int> path = new HashSet<Vector2Int> { startPos };
            var prevPos = startPos;

            for (int i = 0; i < walkLength; i++) {
                var newPos = prevPos + Direction2D.GetRandomCardinalDirection();
                path.Add(newPos);
                prevPos = newPos;
            }

            return path;
        }

        public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPos, int corridorLength) {
            List<Vector2Int> corridor = new List<Vector2Int>();
            var direction = Direction2D.GetRandomCardinalDirection();
            corridor.Add(direction);
            var currentPos = startPos;
            for (int i = 0; i < corridorLength; i++) {
                currentPos += direction;
                corridor.Add(currentPos);
            }

            return corridor;
        }

        public static List<BoundsInt> BinarySpacePartitioning(BoundsInt spaceToSplit, int minWidth, int minHeight) {
            Queue<BoundsInt> roomsQueue = new Queue<BoundsInt>();
            List<BoundsInt> roomsList = new List<BoundsInt>();
            roomsQueue.Enqueue(spaceToSplit);
            while (roomsQueue.Count > 0) {
                var room = roomsQueue.Dequeue();
                if (room.size.y >= minHeight && room.size.x >= minWidth) {
                    if (Random.value < 0.5f) {
                        if (room.size.y >= minHeight * 2) {
                            SplitHorizontally(minHeight, roomsQueue, room);
                        }
                        else if (room.size.x >= minWidth * 2) {
                            SplitVertically(minWidth, roomsQueue, room);
                        }
                        else if (room.size.x >= minWidth && room.size.y >= minHeight) {
                            roomsList.Add(room);
                        }
                    }
                    else {
                        if (room.size.x >= minWidth * 2) {
                            SplitVertically(minWidth, roomsQueue, room);
                        }
                        else if (room.size.y >= minHeight * 2) {
                            SplitHorizontally(minHeight, roomsQueue, room);
                        }
                        else if (room.size.x >= minWidth && room.size.y >= minHeight) {
                            roomsList.Add(room);
                        }
                    }
                }
            }

            return roomsList;
        }

        private static void SplitVertically(int minWidth, Queue<BoundsInt> roomsQueue, BoundsInt room) {
            var xSplit = Random.Range(1, room.size.x);
            BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(xSplit, room.size.y, room.size.z));
            BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x + xSplit, room.min.y, room.min.z),
                new Vector3Int(room.size.x - xSplit, room.size.y, room.size.z));
            roomsQueue.Enqueue(room1);
            roomsQueue.Enqueue(room2);
        }

        private static void SplitHorizontally(int minHeight, Queue<BoundsInt> roomsQueue, BoundsInt room) {
            var ySplit = Random.Range(1, room.size.y); // (minHeight, room.size.y-minHeight)
            BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(room.size.x, ySplit, room.size.z));
            BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x, room.min.y + ySplit, room.min.z),
                new Vector3Int(room.size.x, room.size.y - ySplit, room.size.z));
            roomsQueue.Enqueue(room1);
            roomsQueue.Enqueue(room2);
        }
    }

    public static class Direction2D {
        public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>
        {
            new Vector2Int(0,1), //UP
            new Vector2Int(1,0), //RIGHT
            new Vector2Int(0, -1), // DOWN
            new Vector2Int(-1, 0) //LEFT
        };

        public static List<Vector2Int> diagonalDirectionsList = new List<Vector2Int>
        {
            new Vector2Int(1,1), //UP-RIGHT
            new Vector2Int(1,-1), //RIGHT-DOWN
            new Vector2Int(-1, -1), // DOWN-LEFT
            new Vector2Int(-1, 1) //LEFT-UP
        };

        public static List<Vector2Int> eightDirectionsList = new List<Vector2Int>
        {
            new Vector2Int(0,1), //UP
            new Vector2Int(1,1), //UP-RIGHT
            new Vector2Int(1,0), //RIGHT
            new Vector2Int(1,-1), //RIGHT-DOWN
            new Vector2Int(0, -1), // DOWN
            new Vector2Int(-1, -1), // DOWN-LEFT
            new Vector2Int(-1, 0), //LEFT
            new Vector2Int(-1, 1) //LEFT-UP

        };

        public static Vector2Int GetRandomCardinalDirection()
        {
            return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)];
        }
    }
}