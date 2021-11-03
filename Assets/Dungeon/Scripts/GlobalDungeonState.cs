using System;
using Dungeon.DungeonGeneration;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Dungeon.Scripts
{
    public class GlobalDungeonState : MonoBehaviour
    {
        #region SingletonPattern

        private static GlobalDungeonState instance;

        public static GlobalDungeonState Instance
        {
            get
            {

                if (!instance)
                {
                    Debug.LogWarning("GlobalDungeonState Instance does not Exist!");
                    //throw new Exception("GlobalDungeonState Instance does not Exist");
                }

                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Debug.LogWarning("Instance already exist.");
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        #endregion

        public DungeonState nextRoomState = DungeonState.Level1;

        public AbstractDungeonGeneratorParameterSo levelRoom;
        public AbstractDungeonGeneratorParameterSo bossRoom;

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
    }

    public enum DungeonState
    {
        Level1,
        Level2,
        BossRoom
    }
}