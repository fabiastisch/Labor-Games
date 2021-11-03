using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InGameMenu : CasualButtons
{
    // Start is called before the first frame update

    public PlayerInput playerInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetBackToGame(GameObject parentMenu)
    {
        playerInput.SwitchCurrentActionMap("Player");
        parentMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
