using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public new Camera camera;
    public float movementspeed;
    public SpriteRenderer playSprite;
    private Rigidbody2D rg;


    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }

    void Update()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        move();
    }

    private void dogeRole()
    {

    }

    private void move()
    {
        float axesX = Input.GetAxis("Horizontal");
        float axesY = Input.GetAxis("Vertical");
        rg.velocity = new Vector2(movementspeed * axesX, movementspeed * axesY);
    }

    private void openInventory()
    {

    }
}
