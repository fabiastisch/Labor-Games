using System;
using System.Collections.Generic;
using Dungeon.DungeonGeneration;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utils;

namespace Dungeon.Scripts
{
    public class GlobalDungeonState : GenericSingleton<GlobalDungeonState>
    {

        public DungeonState nextRoomState = DungeonState.Level1;

        public List<AbstractDungeonGeneratorParameterSo> levelRooms;
        public List<AbstractDungeonGeneratorParameterSo> bossRooms;

        [Header("Tiles")] public TileBase floorTile;

        public TileBase
            wallTop,
            wallSideRight,
            wallSideLeft,
            wallBottom,
            wallFull,
            wallInnerCornerDownLeft,
            wallInnerCornerDownRight,
            wallDiagonalCornerDownRight,
            wallDiagonalCornerDownLeft,
            wallDiagonalCornerUpRight,
            wallDiagonalCornerUpLeft;

        public GameObject torchLeft;

        public void GoNext()
        {
            // Go to next enum value and back to first.
            int count = Enum.GetValues(typeof(DungeonState)).Length;
            nextRoomState = (DungeonState) (((int) nextRoomState + 1) % count);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                GoNext();
            }
        }

        public AbstractDungeonGeneratorParameterSo GetBossRoom()
        {
            return bossRooms.GetRandomValue();
        }

        public AbstractDungeonGeneratorParameterSo GetLevelRoom()
        {
            return levelRooms.GetRandomValue();
        }
        protected override void InternalInit()
        {
        }
        protected override void InternalOnDestroy()
        {
        }
    }

    public enum DungeonState
    {
        Level1,
        Level2,
        BossRoom
    }
}