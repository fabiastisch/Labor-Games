using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
