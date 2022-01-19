using System;
using System.Collections.Generic;
using Combat;
using Dungeon.Scripts;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Dungeon.DungeonGeneration
{
    public class DungeonGenerator : GenericSingleton<DungeonGenerator>
    {
        public GameObject spawn;
        public GameObject portal;
        public TilemapVisualizer tilemapVisualizer;
        public TilemapVisualizer bonusRoomTileMapVis;
        public DungeonTilesSo dungeonTiles;
        public GameObject trapRoom;

        //[Header("Select Generator")] public DungeonGeneratorType generatorType;
        public AbstractDungeonGeneratorParameterSo parameterSo;

        public DungeonTrapsSo dungeonTraps;

        [SerializeField] private bool clearDungeonOnGenerate = true;
        [SerializeField] private bool generateOnPlay = false;

        public List<GameObject> traps = new List<GameObject>();

        [Header("Color")]
        public bool overrideConfigColor = false;


        private AbstractDungeonGenerator _generator;

        public DamageType? _dungeonDamageTyp = null;

        private void Start()
        {
            // Ignore Player and Enemy layer collision
            Physics2D.IgnoreLayerCollision(6, 7);
        }

        private void RunProceduralGeneration()
        {
            Debug.Log("Start Procedural Dungeon Generation: " + parameterSo.generatorType);
            switch (parameterSo.generatorType)
            {
                case DungeonGeneratorType.RoomDungeon:
                    _generator = new RoomDungeonGenerator(parameterSo as RoomDungeonGeneratorSo, this);
                    break;
                case DungeonGeneratorType.CorridorFirst:
                    //TODO: bugfixes and spawn & portal
                    _generator =
                        new CorridorFirstDungeonGenerator(parameterSo as CorridorFirstDungeonGeneratorSo, this);
                    break;
                case DungeonGeneratorType.RoomFirst:
                    _generator = new RoomFirstDungeonGenerator(parameterSo as RoomFirstDungeonGeneratorSo, this);
                    break;
                case DungeonGeneratorType.SimpleRandomWalk:
                    //TODO: bugfixes and spawn & portal
                    _generator =
                        new SimpleRandomWalkDungeonGenerator(parameterSo as SimpleRandomWalkDungeonGeneratorSo, this);
                    break;
            }

            if (_generator != null)
            {
                _generator.RunProceduralGeneration();
            }
            else Debug.LogError("Generator is null, type: " + parameterSo.generatorType);

            if (parameterSo.useSpawn)
            {

            }
        }

        public void ActivateBonusRoom(bool active = true)
        {
            tilemapVisualizer.wallTileMap.gameObject.SetActive(!active);
            bonusRoomTileMapVis.floorTilemap.gameObject.SetActive(active);
            bonusRoomTileMapVis.wallTileMap.gameObject.SetActive(active);
        }

        public void GenerateDungeon()
        {
            if (tilemapVisualizer && clearDungeonOnGenerate) ClearDungeon();
            if (parameterSo.overrideDefaultColor && !overrideConfigColor) ChangeColor();
            if (overrideConfigColor) RandomColors();
            ActivateBonusRoom(false);
            RunProceduralGeneration();
        }
        private void RandomColors()
        {
            var array = Enum.GetValues(typeof(DamageType));
            DamageType type = (DamageType) array.GetValue(Random.Range(0, array.Length - 1));
            Color primary = ElementColoring.GetColorByDamageTyp(type);
            _dungeonDamageTyp = type;
            Color secondary = Color.Lerp(primary, Color.white, 0.8f);
            tilemapVisualizer.SetColor(secondary, primary);
            bonusRoomTileMapVis.SetColor(secondary, primary);
        }

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

        private void ChangeColor()
        {
            tilemapVisualizer.SetColor(parameterSo.floorColor, parameterSo.wallColor);
            bonusRoomTileMapVis.SetColor(parameterSo.floorColor, parameterSo.wallColor);
        }

        public GameObject Instantiate(GameObject g, Vector3 position, Quaternion? rot = null)
        {
            Quaternion rotation = (rot ?? Quaternion.identity);
            GameObject obj = Instantiate(g, position, rotation, transform);
            traps.Add(obj);
            return obj;
        }

        public AbstractDungeonLevel CreateSave()
        {
            var so = ScriptableObject.CreateInstance<AbstractDungeonLevel>();

            return so;
        }


        public void SpawnEnemies(List<BoundsInt> rooms)
        {
            foreach (EnemyConfig enemyConfig in parameterSo.enemiesSo.config)
            {
                for (int i = 0; i < enemyConfig.count; i++)
                {
                    Instantiate(enemyConfig.enemy, Util.GetRandomPosition(rooms.GetRandomValue()));
                }
            }

            if (!parameterSo.enemiesSo.randomAdditive) return;
            var enemiesCount = parameterSo.enemiesSo.randomAdditiveCount;

            var roomsCount = rooms.Count;
            rooms.Sort((first, sec) => (int) (sec.size - first.size).magnitude);
            //Enemy prefab = EnemyManager.Instance.GetEnemy("bat");
            foreach (var room in rooms)
            {
                for (int i = 0; i < enemiesCount / roomsCount; i++)
                {
                    GameObject prefab = parameterSo.enemiesSo.config.GetRandomValue().enemy;
                    Instantiate(prefab, Util.GetRandomPosition(room));
                }
            }

        }
        public void SpawnEnemies(HashSet<Vector2Int> floors)
        {
            BoundsInt bounds = tilemapVisualizer.floorTilemap.cellBounds;

            foreach (EnemyConfig enemyConfig in parameterSo.enemiesSo.config)
            {
                for (int i = 0; i < enemyConfig.count; i++)
                {
                    Instantiate(enemyConfig.enemy, Util.GetRandomPosition(bounds));
                }
            }

            if (!parameterSo.enemiesSo.randomAdditive) return;

            var enemiesCount = parameterSo.enemiesSo.randomAdditiveCount;

            for (int i = 0; i < enemiesCount; i++)
            {
                GameObject prefab = parameterSo.enemiesSo.config.GetRandomValue().enemy;
                Instantiate(prefab, Util.GetRandomPosition(bounds));
            }

        }
        protected override void InternalInit()
        {
            if (generateOnPlay)
            {
                var state = GlobalDungeonState.instance;
                if (state.nextRoomState == DungeonState.BossRoom)
                {
                    parameterSo = state.GetBossRoom();
                }
                else parameterSo = state.GetLevelRoom();

                state.GoNext();

                GenerateDungeon();
            }
        }
        protected override void InternalOnDestroy()
        {
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