using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute( menuName = "Passives/CooldownReduction")]
public class CooldownReduction : Passive
{
    public float cooldownReduction = 15f;
    private StatTypeListSO statTypeList;
    
    private void Awake()
    { 
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }
    
    public override void Activation(GameObject parent)
    {
        Debug.Log("CooldownReduction Perk Activation");
        // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        //
        // player.spellCoolDownReduction += cooldownReduction;
        //
        // player.GetStats();
        StatManager.Instance.AddStat(statTypeList.list[4], cooldownReduction);

    }

    public override void BeginCooldown(GameObject parent)
    {
        Debug.Log("CooldownReduction deactivated");
        // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        //
        // player.spellCoolDownReduction -= cooldownReduction;
        //
        // player.GetStats();
        StatManager.Instance.RemoveStat(statTypeList.list[4], cooldownReduction);
        
    }
}
