using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : CasualButtons
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetBackToGame(GameObject parentMenu)
    {
        parentMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
