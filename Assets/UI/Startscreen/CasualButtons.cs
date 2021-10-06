using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CasualButtons : MonoBehaviour
{
    /* 
     * Go back to the current menu.
     * Is the canvas null hide menu.
     * Use only if the current menu is the only one in canvas.
     */
    public void ChangeMenuSingle(GameObject menu = null)
    {
        gameObject.SetActive(false);
        if (menu == null) return;
        menu.SetActive(true);
    }

    /*
     * Redirekts to a menu.
     * Use if the current menu isnt the only on in the canvas.
     */

    public void ChangeMenuMultiple(GameObject menuToOpen)
    {
        menuToOpen.gameObject.SetActive(true);
        GameObject currentMenu = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        currentMenu.SetActive(false);
    }


    //Quits the game.
    public void QuitGame()
    {
        Application.Quit();
    }
}
