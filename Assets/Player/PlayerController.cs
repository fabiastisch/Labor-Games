using UnityEngine;

namespace Player {
    public class PlayerController : MonoBehaviour {
        [SerializeField] private Camera cam;
        [SerializeField] private SpriteRenderer playSprite;

        [Header("Movement")] [SerializeField] private float movementSpeed;
        private Vector2 movement;

        private Rigidbody2D rb;

        private Vector2 MousePosition {
            get {
                Vector2 mouseOnScreen = cam.ScreenToWorldPoint(Input.mousePosition);
                return (mouseOnScreen - (Vector2)transform.position).normalized;
            }
        }

        //Dodging, stamina used as Cost
        [Header("Dodging")] [SerializeField] private float stamina = 100f;
        [SerializeField] private float staminaReg = 5;
        [SerializeField] private float dodgeCost = 44f;
        [SerializeField] private float dodgeSpeed;
        private float dodgeSpeedMax;
        private float maxStamina;
        private Vector2 currentDodgeDirection = Vector2.zero;

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
                currentDodgeDirection = Vector2.zero;
                state = State.Normal;
                //rb.velocity = Vector2.zero;
            }

            //rb.velocity = currentDodgeDirection * dodgeSpeed;
            rb.MovePosition((Vector2)transform.position + currentDodgeDirection * dodgeSpeed * Time.fixedDeltaTime);

        }

        void Update() {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Not needed if Cam is a child object
            // cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);

            if (stamina < maxStamina) {
                stamina += staminaReg * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space) && stamina >= dodgeCost && state == State.Normal) {
                stamina -= dodgeCost;
                dodgeSpeed = dodgeSpeedMax;
                currentDodgeDirection = MousePosition;
                state = State.Dodging;
            }
        }

        //Movement
        private void move() {
            ChangeSpriteDirection(movement.x);
            //rb.velocity = movement * movementSpeed;
            rb.MovePosition((Vector2)transform.position + movement.normalized * (movementSpeed * Time.fixedDeltaTime));
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
    }
}