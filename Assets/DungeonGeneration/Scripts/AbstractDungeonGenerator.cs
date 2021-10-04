using UnityEngine;

namespace DungeonGeneration {
    public abstract class AbstractDungeonGenerator : MonoBehaviour {
        [SerializeField] protected TilemapVisualizer tilemapVisualizer = null;
        [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;

        public void GenerateDungeon() {
            if (tilemapVisualizer) tilemapVisualizer.Clear();
            RunProceduralGeneration();
        }

        protected abstract void RunProceduralGeneration();

        public void ClearDungeon() {
            if (tilemapVisualizer) tilemapVisualizer.Clear();
        }
    }
}