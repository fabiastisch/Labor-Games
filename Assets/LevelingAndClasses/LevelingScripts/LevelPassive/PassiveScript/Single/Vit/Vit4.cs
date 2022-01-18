using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Vit/Invincible")]
public class Vit4 : LevelPassive
{

    public override void Activation(GameObject parent)
    {
        Util.GetLocalPlayer().Invulnerable = true;
    }

    public override void BeginCooldown(GameObject parent)
    {
        Util.GetLocalPlayer().Invulnerable = false;
    }

    public override void Removed(GameObject parent)
    {
        Util.GetLocalPlayer().Invulnerable = false;
    }
}
