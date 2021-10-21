﻿using System.Collections.Generic;
using UnityEngine;

namespace DungeonGeneration.Scripts
{
    public abstract class AbstractDungeonGenerator : MonoBehaviour
    {
        [HideInInspector] public GameObject portal;
        [HideInInspector] public GameObject spawn;
        [HideInInspector] public TilemapVisualizer tilemapVisualizer = null;
        [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;
        [SerializeField] protected bool clearDungeonOnGenerate = true;
        [SerializeField] private bool generateOnPlay = false;
        protected GameObject _portal;
        protected GameObject _spawn;
        [HideInInspector] public GameObject trapRoom;
        protected List<GameObject> traps = new List<GameObject>();
        [HideInInspector] public TilemapVisualizer bonusRoomTileMapVis;


        public virtual void Awake()
        {
            if (generateOnPlay)
            {
                ActivateBonusRoom(false);
                GenerateDungeon();
            }
        }

        public void GenerateDungeon()
        {
            if (tilemapVisualizer && clearDungeonOnGenerate) ClearDungeon();
            ActivateBonusRoom(false);
            RunProceduralGeneration();
        }

        public void ActivateBonusRoom(bool active = true)
        {
            tilemapVisualizer.wallTileMap.gameObject.SetActive(!active);
            bonusRoomTileMapVis.floorTilemap.gameObject.SetActive(active);
            bonusRoomTileMapVis.wallTileMap.gameObject.SetActive(active);
        }

        protected abstract void RunProceduralGeneration();

        public void ClearDungeon()
        {
            if (tilemapVisualizer) tilemapVisualizer.Clear();
            if (bonusRoomTileMapVis) bonusRoomTileMapVis.Clear();
            for (int i = 0; i < traps.Count; i++)
            {
                if (traps[i])
                {
                    DestroyImmediate(traps[i]);
                }
            }

            traps = new List<GameObject>();
        }

        public void ClearObjectsImmediate()
        {
            Debug.Log("ClearObjectsImmediate");
            if (_portal) DestroyImmediate(_portal);
            _portal = null;
            if (_spawn) DestroyImmediate(_spawn);
            _spawn = null;
        }
    }
}