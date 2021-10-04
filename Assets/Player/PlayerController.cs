using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public new Camera camera;
    public float movementspeed;
    public SpriteRenderer playSprite;
    private Rigidbody2D rg;

    private Vector2 mousePosition;

    //Doging only for stamian
    public float stamina = 100f;
    public float staminaReg = 0.01f;
    public float dodgeCost = 44f;
    public float dodgeSpeed;
    private float dodgeSpeedMax;
    private float maxStamina;

    float axesX;
    float axesY;

    //State which the player is currently in
    private enum State
    {
        Normal,
        Dodging
    }

    private State state;


    void Start()
    {
        state = State.Normal;
        rg = gameObject.GetComponent<Rigidbody2D>();
        maxStamina = stamina;
        dodgeSpeedMax = dodgeSpeed;
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Normal:
                move();
                break;
            case State.Dodging:
                dodgeSpeed = dodgeSpeed - 1.7f;
                if (dodgeSpeed <= 0)
                {
                    state = State.Normal;
                    rg.velocity = Vector2.zero;
                }
                rg.velocity = new Vector2(dodgeSpeed * mousePosition.x, dodgeSpeed * mousePosition.y);
                break;
        }
    }

    void Update()
    {
        axesX = Input.GetAxis("Horizontal");
        axesY = Input.GetAxis("Vertical");
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);

        if (stamina < maxStamina)
        {
            stamina = stamina + staminaReg;
        }

        getMousePosition();

        if (Input.GetKeyDown(KeyCode.Space) && stamina >= dodgeCost && state == State.Normal)
        {
            state = State.Dodging;
            dodgeSpeed = dodgeSpeedMax;
            dodge();
        }
    }

    //Movement
    private void dodge()
    {
        stamina = stamina - dodgeCost;
        rg.velocity = new Vector2(mousePosition.x * dodgeSpeed, mousePosition.y * dodgeSpeed);
    }

    private void move()
    {
        ChangeSpriteDirection(axesX);
        rg.velocity = new Vector2(movementspeed * axesX, movementspeed * axesY);
    }

    //UI
    private void openInventory()
    {

    }

    private void openOptions()
    {

    }

    private void interact()
    {

    }

    //Swaps the sprite to the moving direction.
    private void ChangeSpriteDirection(float direction)
    {

        if (direction < 0)
        {
            playSprite.flipX = true;
        }
        if (direction > 0)
        {
            playSprite.flipX = false;
        }
    }

    //Gets the mousposition for dodging
    private void getMousePosition()
    {
        Vector3 mouseOnScreen = Input.mousePosition;
        mouseOnScreen = Camera.main.ScreenToWorldPoint(mouseOnScreen);
        mousePosition = new Vector2(mouseOnScreen.x - transform.position.x, mouseOnScreen.y - transform.position.y).normalized;
    }
}
