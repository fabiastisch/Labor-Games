using UnityEngine;

namespace DungeonGeneration.Scripts {
    public abstract class AbstractDungeonGenerator : MonoBehaviour {
        [HideInInspector] public TilemapVisualizer tilemapVisualizer = null;
        [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;
        [SerializeField] protected bool clearDungeonOnGenerate = true;
        [SerializeField] private bool generateOnPlay = false;

        private void Awake() {
            if (generateOnPlay) {
                GenerateDungeon();
            }
        }

        public void GenerateDungeon() {
            if (tilemapVisualizer && clearDungeonOnGenerate) tilemapVisualizer.Clear();
            RunProceduralGeneration();
            TabMap.OnSingletonStarted += () => TabMap.Instance.UpdateMap();
        }
