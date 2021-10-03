using UnityEngine;
using Utils;

namespace Character {
    public class PlayerController : MonoBehaviour {
        [SerializeField] private float speed = 10f;

        private Rigidbody2D _rb;

        private Coroutine _coroutine = null;

        // Start is called before the first frame update
        void Start() {
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update() {
            float horizontal = Input.GetAxis("Horizontal"); // d = 1, a = -1
            float vertical = Input.GetAxis("Vertical"); // w = 1 , s = -1 
            Vector2 velocity = new Vector2(horizontal, vertical);
            _rb.velocity = velocity * speed;

            if (Input.GetKey(KeyCode.P)) { // Test Dungeon Switch
                if (_coroutine == null) {
                    _coroutine = StartCoroutine(CustomSceneManager.LoadYourAsyncScene("Dungeon", gameObject));
                }

            }
        }
    }
}