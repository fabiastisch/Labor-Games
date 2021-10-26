using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.DungeonGeneration
{
    public class DungeonGenerator : MonoBehaviour
    {
        public GameObject spawn;
        public GameObject portal;
        public TilemapVisualizer tilemapVisualizer;
        public TilemapVisualizer bonusRoomTileMapVis;
        public GameObject trapRoom;

        //[Header("Select Generator")] public DungeonGeneratorType generatorType;
        public DungeonGeneratorParameterSo parameterSo;

        [SerializeField] protected bool clearDungeonOnGenerate = true;
        [SerializeField] private bool generateOnPlay = false;

        [HideInInspector] public GameObject currentPortal;
        [HideInInspector] public GameObject currentSpawn;
        public List<GameObject> traps = new List<GameObject>();

        [Header("Color")] [SerializeField] protected Color floorColor;
        [SerializeField] protected Color wallColor;
        [SerializeField] protected bool overrideDefaultColor = false;

        private AbstractDungeonGeneratorNew _generatorNew;

        private void RunProceduralGeneration()
        {
            switch (parameterSo.generatorType)
            {
                case DungeonGeneratorType.RoomDungeon:
                    _generatorNew = new RoomDungeonGenerator(parameterSo, this);
                    break;
                case DungeonGeneratorType.CorridorFirst:
                    _generatorNew = new CorridorFirstDungeonGenerator(parameterSo, this);
                    break;
                case DungeonGeneratorType.RoomFirst:
                    _generatorNew = new RoomFirstDungeonGenerator(parameterSo, this);
                    break;
                case DungeonGeneratorType.SimpleRandomWalk:
                    _generatorNew = new SimpleRandomWalkDungeonGenerator(parameterSo, this);
                    break;
            }

            if (_generatorNew != null)
            {
                _generatorNew.RunProceduralGeneration();
            }
            else Debug.LogError("Generator is null, type: " + parameterSo.generatorType);
        }

        private void Awake()
        {
            if (generateOnPlay)
            {
                GenerateDungeon();
            }
        }

        private void ActivateBonusRoom(bool active)
        {
            tilemapVisualizer.wallTileMap.gameObject.SetActive(!active);
            bonusRoomTileMapVis.floorTilemap.gameObject.SetActive(active);
            bonusRoomTileMapVis.wallTileMap.gameObject.SetActive(active);
        }

        private void GenerateDungeon()
        {
            if (tilemapVisualizer && clearDungeonOnGenerate) ClearDungeon();
            if (overrideDefaultColor) ChangeColor();
            ActivateBonusRoom(false);
            RunProceduralGeneration();
        }

        private void ClearDungeon()
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

        private void ChangeColor()
        {
            tilemapVisualizer.SetColor(floorColor, wallColor);
            bonusRoomTileMapVis.SetColor(floorColor, wallColor);
        }

        public void Instantiate(GameObject g, Vector3 position)
        {
            Instantiate(g, position, Quaternion.identity, transform);
        }
    }


    public enum DungeonGeneratorType
    {
        CorridorFirst = 0,
        RoomDungeon = 1,
        RoomFirst = 2,
        SimpleRandomWalk = 3
    }
}