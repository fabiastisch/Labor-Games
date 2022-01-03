
using UnityEngine;
using Utils;

public class MouseTrack : MonoBehaviour
{
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetMouseWorldPositon()
    {
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //in 2D Games its better to have it in One Dimension
        return mouseWorldPosition;
    }
    
    public Vector2 GetPlayerToMousePosition()
    {
        GameObject player = Util.GetLocalPlayer().gameObject;
        Vector2 mouseDirection = (player.GetComponent<MouseTrack>().GetMouseWorldPositon() - (Vector2)player.transform.position).normalized;
        //in 2D Games its better to have it in One Dimension
        return mouseDirection;
    }

    public Quaternion GetRotationToMouse()
    {
        Quaternion rotation = Quaternion.Euler(Vector3.forward *  Util.GetAngleFromVector(GetPlayerToMousePosition()));
        return rotation;
    } 
}
