using UnityEngine;

namespace Player {
    public class PlayerController : MonoBehaviour {
        [SerializeField] private Camera cam;
        [SerializeField] private SpriteRenderer playSprite;

        [Header("Movement")] [SerializeField] private float movementSpeed;
        private Vector2 movement;

        private Rigidbody2D rb;

        private Vector2 mousePosition;

        //Dodging, stamina used as Cost
        [Header("Dodging")] [SerializeField] private float stamina = 100f;
        [SerializeField] private float staminaReg = 0.01f;
        [SerializeField] private float dodgeCost = 44f;
        [SerializeField] private float dodgeSpeed;
        private float dodgeSpeedMax;
        private float maxStamina;

        float axesX;
        float axesY;

        #region PlayerState

        private State state;

        //State which the player is currently in
        private enum State {
            Normal,
            Dodging
        }

        #endregion

        void Start() {
            state = State.Normal;
            rb = gameObject.GetComponent<Rigidbody2D>();
            maxStamina = stamina;
            dodgeSpeedMax = dodgeSpeed;
        }

        private void FixedUpdate() {
            switch (state) {
                case State.Normal:
                    move();
                    break;
                case State.Dodging:
                    PerformDodgeStep();
                    break;
            }
        }

        private void PerformDodgeStep() {
            dodgeSpeed -= 1.7f; // Todo: Whats that?
            if (dodgeSpeed <= 0) {
                state = State.Normal;
                rb.velocity = Vector2.zero;
            }

            rb.velocity = mousePosition * dodgeSpeed;
        }

        void Update() {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);

            if (stamina < maxStamina) {
                stamina += staminaReg;
            }

            getMousePosition();

            if (Input.GetKeyDown(KeyCode.Space) && stamina >= dodgeCost && state == State.Normal) {
                dodgeSpeed = dodgeSpeedMax;
                state = State.Dodging;
            }
        }

        //Movement
        private void move() {
            ChangeSpriteDirection(movement.x);
            rb.velocity = movement * movementSpeed;
        }

        //UI
        private void openInventory() {
        }

        private void openOptions() {
        }

        private void interact() {
        }

        //Swaps the sprite to the moving direction.
        private void ChangeSpriteDirection(float direction) {
            if (direction < 0) {
                playSprite.flipX = true;
            }
            else if (direction > 0) {
                playSprite.flipX = false;
            }
        }

        //Gets the mousposition for dodging
        private void getMousePosition() {
            Vector2 mouseOnScreen = Input.mousePosition;
            mouseOnScreen = Camera.main.ScreenToWorldPoint(mouseOnScreen);
            mousePosition = (mouseOnScreen - (Vector2)transform.position).normalized;
        }
    }
}