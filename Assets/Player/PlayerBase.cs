using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public abstract class PlayerBase : MonoBehaviour {
        [SerializeField] private Camera cam;
        [SerializeField] private SpriteRenderer playSprite;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private GameObject menu;
        [SerializeField] private Texture2D cursor;
        private PlayerInput playerInput;


        [Header("Movement")] [SerializeField] private float movementSpeed = 9f;
        private Vector2 movement;

        private Vector2 MousePosition {
            get {
                Vector2 mouseOnScreen = cam.ScreenToWorldPoint(Input.mousePosition);
                return (mouseOnScreen - (Vector2)transform.position).normalized;
            }
        }

        //Dodging, stamina used as Cost
        [Header("Dodging")] [SerializeField] private float stamina = 100f;
        [SerializeField] private float staminaReg = 10f;
        [SerializeField] private float dodgeCost = 44f;
        [SerializeField] private float dodgeSpeed = 30f;
        private float dodgeSpeedMax;
        private float maxStamina;
        private Vector2 currentDodgeDirection = Vector2.zero;
        private bool isMenuOpen = false;

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

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            
        }

        protected virtual void Start() {
            state = State.Normal;
            maxStamina = stamina;
            dodgeSpeedMax = dodgeSpeed;
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        }

        protected virtual void FixedUpdate() {
            switch (state) {
                case State.Normal:
                    Move();
                    break;
                case State.Dodging:
                    PerformDodgeStep();
                    break;
            }
        }

        protected virtual void Update() {
            Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
            movement.x = moveInput.x;
            movement.y = moveInput.y;

            if (stamina < maxStamina) {
                stamina += staminaReg * Time.deltaTime;
            }

            bool isIngameMenuOpen = menu.gameObject.activeSelf;

            if (playerInput.actions["Dodge"].triggered && stamina >= dodgeCost && state == State.Normal && !isIngameMenuOpen) {
                stamina -= dodgeCost;
                dodgeSpeed = dodgeSpeedMax;
                currentDodgeDirection = MousePosition;
                state = State.Dodging;
            }
        }

        //Movement
        private void Move() {
            ChangeSpriteDirection(movement.x);
            //rb.velocity = movement * movementSpeed;
            rb.MovePosition((Vector2)transform.position + movement.normalized * (movementSpeed * Time.fixedDeltaTime));
        }

        private void PerformDodgeStep()
        {
            dodgeSpeed -= 1.7f;
            if (dodgeSpeed <= 0)
            {
                currentDodgeDirection = Vector2.zero;
                state = State.Normal;
                return;
                //rb.velocity = Vector2.zero;
            }

            //rb.velocity = currentDodgeDirection * dodgeSpeed;
            rb.MovePosition((Vector2)transform.position + currentDodgeDirection * dodgeSpeed * Time.fixedDeltaTime);
        }

        //UI
        public void OpenInventory() {
        }

        public void OpenMinimap() {

        }

        public void OpenMenu() {
            isMenuOpen = menu.gameObject.activeSelf;
            if (!isMenuOpen)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
                
            }
            else
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }
            
        }

        #region Spellcast
        public abstract void CastAbillity1();


        public abstract void CastAbillity2();


        public abstract void CastAbillity3();


        public abstract void CastAbillity4();


        public abstract void CastAbillity5();

        public abstract void CastPrimaryAttack();
        #endregion

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