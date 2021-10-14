using System;
using System.Linq;
using UnityEngine;

namespace DungeonGeneration.Scripts {
    [RequireComponent(typeof(MeshFilter))]
    public class TabMap : MonoBehaviour {
        #region SingletonPattern

        private static TabMap instance;

        public static TabMap Instance {
            get => instance;
        }

        public static event Action OnSingletonReady;
        public static event Action OnSingletonStarted;

        private void Awake() {
            if (instance == null) {
                instance = this;
                OnSingletonReady?.Invoke();
            }
            else if (instance != this) {
                Debug.LogWarning("TabMap already exist.");
                Destroy(gameObject);
            }
        }

        #endregion

        [SerializeField] private TilemapVisualizer tilemapVisualizer;

        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;

        // Start is called before the first frame update
        void Start() {
            _meshFilter = GetComponent<MeshFilter>();
            //_mesh = new Mesh();
            Debug.Log("Start");
            OnSingletonStarted?.Invoke();
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.enabled = false;
        }

        public void UpdateMap() {
            var mesh = new Mesh();
            int verticesCount = tilemapVisualizer.FloorTiles.Count() * 6;
            Vector3[] vertices = new Vector3[verticesCount];
            int index = 0;
            foreach (var tile in tilemapVisualizer.FloorTiles) {
                //TODO: Optimize
                vertices[index++] = new Vector3(tile.x, tile.y); //base
                vertices[index++] = new Vector3(tile.x + 1, tile.y + 1); //top right
                vertices[index++] = new Vector3(tile.x, tile.y + 1); // left

                vertices[index++] = new Vector3(tile.x, tile.y); // base
                vertices[index++] = new Vector3(tile.x + 1, tile.y); // top
                vertices[index++] = new Vector3(tile.x + 1, tile.y + 1); // top right
            }

            mesh.vertices = vertices;

            int[] triangles = new int[verticesCount / 3];
            int[] arr = Enumerable.Range(0, verticesCount).ToArray();
            mesh.triangles = arr;
            _meshFilter.mesh = mesh;


            Debug.Log("Update Map");
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Tab)) {
                _meshRenderer.enabled = !_meshRenderer.enabled;
            }
        }
    }
}