using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Attackspeed", menuName = "Passives/Attackspeed")]
public class Attackspeed : Passive
{
    public float attackspeedvalue = 1.2f;
    private StatTypeListSO statTypeList;
    
    private void Awake()
    { 
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }
    public override void Activation(GameObject parent)
    {
        Debug.Log("Attackspeed Perk Activation");
        
        // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        //
        // player.attackspeed *= attackspeedvalue;
        //
        // player.GetStats();
        
        StatManager.Instance.AddStat(statTypeList.list[2], attackspeedvalue);

    }

    public override void BeginCooldown(GameObject parent)
    {
        Debug.Log("Attackspeed Perk Cooldown if / disabled");
        
        // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        //
        // player.attackspeed /= attackspeedvalue;
        //
        // player.GetStats();
        
        StatManager.Instance.RemoveStat(statTypeList.list[2], attackspeedvalue);
        
    }
}
