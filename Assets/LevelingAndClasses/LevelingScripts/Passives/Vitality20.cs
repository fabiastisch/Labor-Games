using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vitality20 : Passive
{
    public float extraVitallity;

    public override void Activation(GameObject parent)
    {
        //player.hp += 20;
    }

    public override void BeginCooldown(GameObject parent)
    {
        //player.hp -= 20;
    }

}
