using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using Player;
using UnityEngine;
using Utils;

[CreateAssetMenuAttribute(menuName = "LevelPassive/Single/Vit/Shielding")]
public class Vit2 : LevelPassive
{

    [SerializeField] private Shield shield;
    [SerializeField] private float factor = 0.15f;


    public override void Activation(GameObject parent)
    {
        PlayerBase player = Util.GetLocalPlayer();

        if (shield == null)
        {
            // not working, shield is 0
            //shield = new Shield(ActualStatsThatGetUsed.Instance.actualHP * factor);

            shield = new Shield(5);
            player.AddShield(shield);
        }
        else
        {
            shield.RefreshShield();
        }

    }


    public override void BeginCooldown(GameObject parent)
    {
    }

    public override void Removed(GameObject parent)
    {
        if (Util.GetLocalPlayer().shields.HasThisShield(shield))
            Util.GetLocalPlayer().shields.Remove(shield);
    }
}