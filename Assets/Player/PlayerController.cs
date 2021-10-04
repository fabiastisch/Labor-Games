using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public new Camera camera;
    public float movementspeed;
    public SpriteRenderer playSprite;
    private Rigidbody2D rg;

    //Doging
    public float stamina = 100f;
    public float staminaReg = 0.01f;
    public float dogeCost = 44f;
    public float dogeSpeed = 50f;
    private float maxStamina;

    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
        maxStamina = stamina;
    }

    private void FixedUpdate()
    {
        move();
    }

    void Update()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        if (stamina < maxStamina)
        {
            stamina = stamina + staminaReg;
        }

        if (Input.GetKeyDown(KeyCode.Space) && stamina >= dogeCost)
        {
            doge();
        }
    }

    //Movement
    private void doge()
    {
        stamina = stamina - dogeCost;

    }

    private void move()
    {
        float axesX = Input.GetAxis("Horizontal");
        float axesY = Input.GetAxis("Vertical");
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
}
