using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Requirements : MonoBehaviour
{
    public int vitallityScore;
    public int abillityScore;
    public int agillityScore;
    public int charimsaScore;
    public int strengthScore;

    public Sprite lockedSprite;
    public Sprite unlockedSprite;

    private Button buttonholder;

    private bool locked = true;

    private void Start()
    {
        buttonholder = transform.GetComponent<Button>();
        if (locked)
        {
            transform.GetComponent<Image>().sprite = lockedSprite;
        }
    }

    public void UnlockButton()
    {
        if (locked == false) return;
        Debug.Log("Unlocked Button Requirements: Vitallity: " + vitallityScore + " Abillity: " + abillityScore +
                  " Agillity: " + agillityScore + "Charisma: " + charimsaScore + "Strength: " + strengthScore);
        transform.GetComponent<Image>().sprite = unlockedSprite;
        
       // buttonholder.enabled = true;
        locked = false;
        


    }
    
    public void LockButton()
    {
        if (locked) return;
        Debug.Log("Unlocked Button Requirements: Vitallity: " + vitallityScore + " Abillity: " + abillityScore +
                                             " Agillity: " + agillityScore + "Charisma: " + charimsaScore + "Strength: " + strengthScore);
        transform.GetComponent<Image>().sprite = lockedSprite;
       // buttonholder.enabled = false;
        locked = true;
        
    }


}
