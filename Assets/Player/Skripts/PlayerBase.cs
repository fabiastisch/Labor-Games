using UnityEngine;
using UnityEngine.InputSystem;
using Utils;


namespace Player
{
    public abstract class PlayerBase : MonoBehaviour
    {
        [SerializeField] [Range(-180, 180)] private int tmpMouseAngle;
        [SerializeField] private bool overrideMouseAngle = false;
        [SerializeField] private Camera cam;
        [SerializeField] private SpriteRenderer playSprite;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private GameObject menu;
        [SerializeField] private Texture2D cursor;
        [SerializeField] private Sprite[] eightWaysSprites;
        [SerializeField] private PlayerHand hand;

        private PlayerInput playerInput;


        [Header("Movement")] [SerializeField] private float movementSpeed = 9f;
        private Vector2 movement;

        private Vector2 MousePosition
        {
            get
            {
                Vector2 mouseOnScreen = cam.ScreenToWorldPoint(Input.mousePosition);
                return (mouseOnScreen - (Vector2) transform.position).normalized;
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
        private enum State
        {
            Normal,
            Dodging
        }

        #endregion

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
        }

        protected virtual void Start()
        {
            state = State.Normal;
            maxStamina = stamina;
            dodgeSpeedMax = dodgeSpeed;
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        }

        protected virtual void FixedUpdate()
        {
            switch (state)
            {
                case State.Normal:
                    Move();
                    break;
                case State.Dodging:
                    PerformDodgeStep();
                    break;
            }
        }

        protected virtual void Update()
        {
            Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
            movement.x = moveInput.x;
            movement.y = moveInput.y;

            ChangeSpriteDirection();

            if (stamina < maxStamina)
            {
                stamina += staminaReg * Time.deltaTime;
            }

            bool isIngameMenuOpen = menu.gameObject.activeSelf;

            if (playerInput.actions["Dodge"].triggered && stamina >= dodgeCost && state == State.Normal &&
                !isIngameMenuOpen)
            {
                stamina -= dodgeCost;
                dodgeSpeed = dodgeSpeedMax;
                currentDodgeDirection = MousePosition;
                state = State.Dodging;
            }
        }

        //Movement
        private void Move()
        {
            //rb.velocity = movement * movementSpeed;
            rb.MovePosition((Vector2) transform.position + movement.normalized * (movementSpeed * Time.fixedDeltaTime));
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
            rb.MovePosition((Vector2) transform.position + currentDodgeDirection * dodgeSpeed * Time.fixedDeltaTime);
        }

        //UI
        public void OpenInventory()
        {
        }

        public void OpenMinimap()
        {
        }

        public void OpenMenu()
        {
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
        private void ChangeSpriteDirection()
        {
            int mouseAngle = Util.GetAngleFromVector(MousePosition);
            if (overrideMouseAngle) mouseAngle = tmpMouseAngle;
            if (mouseAngle >= -112 && mouseAngle <= -68)
            {
                //Down
                playSprite.sprite = eightWaysSprites[0];
                hand.RotateHand(Rotations.Down);
            }
            else if (mouseAngle >= -157 && mouseAngle <= -113)
            {
                //DownLeft
                playSprite.sprite = eightWaysSprites[7];
                hand.RotateHand(Rotations.DownLeft);
            }
            else if (mouseAngle >= 158 || mouseAngle <= -158)
            {
                //Left
                playSprite.sprite = eightWaysSprites[6];
                hand.RotateHand(Rotations.Left);
            }
            else if (mouseAngle <= 157 && mouseAngle >= 113)
            {
                //UpLeft
                playSprite.sprite = eightWaysSprites[5];
                hand.RotateHand(Rotations.UpLeft);
            }
            else if (mouseAngle <= 112 && mouseAngle >= 68)
            {
                //Up
                playSprite.sprite = eightWaysSprites[4];
                hand.RotateHand(Rotations.Up);
            }
            else if (mouseAngle <= 67 && mouseAngle >= 23)
            {
                //UpRight
                playSprite.sprite = eightWaysSprites[3];
                hand.RotateHand(Rotations.UpRight);
            }
            else if (mouseAngle <= 22 && mouseAngle >= -22)
            {
                //Right
                playSprite.sprite = eightWaysSprites[2];
                hand.RotateHand(Rotations.Right);
            }
            else if (mouseAngle <= -23 && mouseAngle >= -67)
            {
                //Down Right
                playSprite.sprite = eightWaysSprites[1];
                hand.RotateHand(Rotations.DownRight);
            }
        }
    }
}