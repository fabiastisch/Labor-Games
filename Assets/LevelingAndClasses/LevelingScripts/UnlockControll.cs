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
   // private Requirements requirement;

    [SerializeField]
    private Statistics statistics;
    public void CheckListForUnlocking()
    {
        Debug.Log("CheckListForUnlocking");
        foreach (var skillListEntry in levelingSkillList)
        {
            Requirements requirement = skillListEntry.GetComponent<Requirements>();
            CheckUnlocking(requirement);
            requirement = null;
        }
        
    }


    private void CheckUnlocking(Requirements requirements)
    {
        Debug.Log("Accessed Unlock");
        if (requirements.vitallityScore > statistics.GetValue(Statistics.Type.Vitallity))
        {
            Debug.Log("Vitallity needed: " + requirements.vitallityScore + " But is: "   + player.statistics.GetValue(Statistics.Type.Vitallity));
            requirements.LockButton();
            return;
        }
        if (requirements.abillityScore >  statistics.GetValue(Statistics.Type.Abillity))
        {
            Debug.Log("Abillity needed: " + requirements.abillityScore + " But is: "   + player.statistics.GetValue(Statistics.Type.Abillity));
            requirements.LockButton();
            return;
        }
        if (requirements.agillityScore >  statistics.GetValue(Statistics.Type.Agillity))
        {
            Debug.Log("Agillity needed: " + requirements.agillityScore + " But is: "   + player.statistics.GetValue(Statistics.Type.Agillity));
            requirements.LockButton();
            return;
        }
        if (requirements.charimsaScore >  statistics.GetValue(Statistics.Type.Charisma))
        {
            Debug.Log("Charisma needed: " + requirements.charimsaScore + " But is: "   + player.statistics.GetValue(Statistics.Type.Charisma));
            requirements.LockButton();
            return;
        }
        if (requirements.strengthScore > statistics.GetValue(Statistics.Type.Strength))
        {
            Debug.Log("Strength needed: " + requirements.strengthScore + " But is: "   + player.statistics.GetValue(Statistics.Type.Strength));
            requirements.LockButton();
            return;
        }
        Debug.Log("Accessed and Unlocked");
        
        requirements.UnlockButton();
    }
    
}
