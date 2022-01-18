using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Vit/LifeReg")]
public class Vit1 : LevelPassive
{
    //OverTimeValue Regen
    [SerializeField] private float factor = 0.05f;

    [SerializeField] private float regenRate;
    public override void Activation(GameObject parent)
    {
        regenRate = ActualStatsThatGetUsed.Instance.actualHP * factor;
        Util.GetLocalPlayer().healthRegeneration += regenRate;
    }

    public override void BeginCooldown(GameObject parent)
    {
    }

    public override void Removed(GameObject parent)
    {
        Util.GetLocalPlayer().healthRegeneration -= regenRate;
    }
}
