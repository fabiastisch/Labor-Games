using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CooldownReduction : Passive
{
    public float cooldownReduction = 15f;
    public override void Activation(GameObject parent)
    {
        Debug.Log("CooldownReduction Perk Activation");
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();

        player.spellCoolDownReduction += cooldownReduction;
        
        player.GetStats();

    }

    public override void BeginCooldown(GameObject parent)
    {
        Debug.Log("CooldownReduction deactivated");
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        
        player.spellCoolDownReduction -= cooldownReduction;
        
        player.GetStats();
        
    }
}
