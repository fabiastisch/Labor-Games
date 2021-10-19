using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockSkills : MonoBehaviour
{
    public Button thisButton;

    void Start()
    {
        Button btn = thisButton.GetComponent<Button>();
        btn.onClick.AddListener(ToggleSkill);
    }
    
    //Activate or Deactivate Passives / Skills
    void ToggleSkill(){
    Debug.Log("Click");
    
    }
    
    //checks if you can use the Skill (can unlock it)
    bool meetsRequirements()
    {
        //if(requirement)
        return true;
        //return false;

    }
    
}
