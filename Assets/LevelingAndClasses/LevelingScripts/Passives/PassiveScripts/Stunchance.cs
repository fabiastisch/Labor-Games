using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "StunChance", menuName = "Passives/StunChance")]
public class Stunchance : Passive
{
    public float stunChance = 15f;
    private StatTypeListSO statTypeList;
    private void Awake()
    { 
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }
    
    public override void Activation(GameObject parent)
    {
        Debug.Log("StunChance Perk Activation");
        
        // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        //
        // player.stunChance += stunChance;
        //
        // player.GetStats();
        StatManager.Instance.AddStat(statTypeList.list[10], stunChance);

    }

    public override void BeginCooldown(GameObject parent)
    {
        Debug.Log("StunChance deactivated");
        
        // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        //
        // player.stunChance -= stunChance;
        //
        // player.GetStats();
        StatManager.Instance.RemoveStat(statTypeList.list[10], stunChance);
        
        
        
    }
}