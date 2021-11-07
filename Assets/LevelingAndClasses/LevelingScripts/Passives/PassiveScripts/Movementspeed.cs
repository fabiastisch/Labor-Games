using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Movementspeed", menuName = "Passives/Movementspeed")]
public class Movementspeed : Passive
{
    public float movementspeed = 1f;
    public override void Activation(GameObject parent)
    {
        Debug.Log("CooldownReduction Perk Activation");
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();

        player.movementspeed += movementspeed;
        
        player.GetStats();

    }

    public override void BeginCooldown(GameObject parent)
    {
        Debug.Log("CooldownReduction deactivated");
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        
        player.movementspeed -= movementspeed;
        
        player.GetStats();
        
    }
}