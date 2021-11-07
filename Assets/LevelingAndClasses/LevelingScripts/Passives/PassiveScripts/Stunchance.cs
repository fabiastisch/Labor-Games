using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "StunChance", menuName = "Passives/StunChance")]
public class Stunchance : Passive
{
    public float stunChance = 15f;
    public override void Activation(GameObject parent)
    {
        Debug.Log("CooldownReduction Perk Activation");
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();

        player.stunChance += stunChance;
        
        player.GetStats();

    }

    public override void BeginCooldown(GameObject parent)
    {
        Debug.Log("CooldownReduction deactivated");
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        
        player.stunChance -= stunChance;
        
        player.GetStats();
        
    }
}