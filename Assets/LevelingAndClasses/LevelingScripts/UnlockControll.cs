using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UnlockControll: MonoBehaviour
{
    
    [Header("List of Classes")] [SerializeField]
    private List<GameObject> levelingSkillList = new List<GameObject>();

    [SerializeField] PassiveTestPlayer player;
    private Requirements requirement;

    public void CheckListForUnlocking()
    {
        Debug.Log("CheckListForUnlocking");
        foreach (var skillListEntry in levelingSkillList)
        {
            requirement = skillListEntry.GetComponent<Requirements>();
            CheckUnlocking(requirement);
        }
        
    }


    private void CheckUnlocking(Requirements requirements)
    {
        Debug.Log("Accessed Unlock");
        if (requirements.vitallityScore > player.statistics.GetValue(Statistics.Type.Vitallity))
        {
            Debug.Log("Vitallity needed: " + requirements.vitallityScore + " But is: "   + player.statistics.GetValue(Statistics.Type.Vitallity));
            requirements.LockButton();
            return;
        }
        if (requirements.abillityScore >  player.statistics.GetValue(Statistics.Type.Abillity))
        {
            requirements.LockButton();
            return;
        }
        if (requirements.agillityScore >  player.statistics.GetValue(Statistics.Type.Agillity))
        {
            requirements.LockButton();
            return;
        }
        if (requirements.charimsaScore >  player.statistics.GetValue(Statistics.Type.Charisma))
        {
            requirements.LockButton();
            return;
        }
        if (requirements.strengthScore > player.statistics.GetValue(Statistics.Type.Strength))
        {
            requirements.LockButton();
            return;
        }
        
        requirements.UnlockButton();
    }
    
}
