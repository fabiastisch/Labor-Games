using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Attackspeed", menuName = "Passives/Attackspeed")]
public class Attackspeed : Passive
{
    public float attackspeedvalue = 1.2f;
    public override void Activation(GameObject parent)
    {
        Debug.Log("Attackspeed Perk Activation");
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();

        player.attackspeed *= attackspeedvalue;
        
        player.GetStats();

    }

    public override void BeginCooldown(GameObject parent)
    {
        Debug.Log("Attackspeed Perk Cooldown if / disabled");
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        
        player.attackspeed /= attackspeedvalue;
        
        player.GetStats();
        
    }
}
