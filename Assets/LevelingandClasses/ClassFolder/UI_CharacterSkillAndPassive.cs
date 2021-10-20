using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CharacterSkillAndPassive: MonoBehaviour
{
    private ClassSlot classPassive1;
    private ClassSlot classPassive2;
    private ClassSlot classPassive3;
    private ClassSlot classPassive4;
    
    private ClassSlot classAbillity1;
    private ClassSlot classAbillity2;
    private ClassSlot classAbillity3;
    private ClassSlot classAbillity4;
    
    private ClassSlot HiddenPassive1;
    private ClassSlot HiddenPassive2;
    private ClassSlot HiddenPassive3;

    private ClassSlot HiddenAbillity1;
    private ClassSlot HiddenAbillity2;

    private ClassSlot Passive1;
    private ClassSlot Passive2;
    private ClassSlot Passive3;
    private ClassSlot Passive4;
    private ClassSlot Passive5;
    private ClassSlot Passive6;
    private ClassSlot Passive7;
    private ClassSlot Passive8;

    private void Awake()
    {
        classAbillity1 = transform.Find("classAbillitySlot1").GetComponent<ClassSlot>();
        classAbillity2 = transform.Find("classAbillitySlot2").GetComponent<ClassSlot>();
        classAbillity3 = transform.Find("classAbillitySlot3").GetComponent<ClassSlot>();
        classAbillity4 = transform.Find("classAbillitySlot4").GetComponent<ClassSlot>();
    }

    private void ClassAbillitySlot1_OnItemDropped(object sender, ClassSlot.OnItemDroppedEventArgs e)
    {
        //Item dropped on first Abillity;
        Debug.Log("Dropped item" + e.skillsAndPassives.GetType());
    }

}
