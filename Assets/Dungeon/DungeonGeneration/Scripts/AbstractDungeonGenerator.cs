using UnityEngine;

namespace DungeonGeneration.Scripts {
    public abstract class AbstractDungeonGenerator : MonoBehaviour {
        [HideInInspector] public GameObject portal;
        [HideInInspector] public GameObject spawn;
        [HideInInspector] public TilemapVisualizer tilemapVisualizer = null;
        [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;
        [SerializeField] protected bool clearDungeonOnGenerate = true;
        [SerializeField] private bool generateOnPlay = false;
        protected GameObject _portal;
        protected GameObject _spawn;

        private void Awake() {
            if (generateOnPlay) {
                GenerateDungeon();
            }
        }

        public void GenerateDungeon() {
            if (tilemapVisualizer && clearDungeonOnGenerate) ClearDungeon();
            RunProceduralGeneration();
        }

        protected abstract void RunProceduralGeneration();

        public void ClearDungeon() {
            if (tilemapVisualizer) tilemapVisualizer.Clear();
        }

        public void ClearObjectsImmediate() {
            Debug.Log("ClearObjectsImmediate");
            if (_portal) DestroyImmediate(_portal);
            _portal = null;
            if (_spawn) DestroyImmediate(_spawn);
            _spawn = null;
        }
    }
}