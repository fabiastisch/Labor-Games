using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "SingleBonus", menuName = "Passives/SingleBonus")]
public class SingleBonus : Passive
{
    [SerializeField] private float statBonusValue = 1.5f;
    private enum Statname{
        vitallity,
        strength,
        abillity,
        agillity,
        charisma,
    }

    [SerializeField] private Statname statname;
    public override void Activation(GameObject parent)
    {
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();

        switch(statname)
        {
            case Statname.vitallity:
                player.MaxHp *= statBonusValue;
                break;
            case Statname.strength:
                player.strength *= statBonusValue;
                break;
            case Statname.abillity:
                player.magicPower *= statBonusValue;
                break;
            case Statname.agillity:
                player.agillity *= statBonusValue;
                break;
            case Statname.charisma:
                player.charisma *= statBonusValue;
                break;
            
        }
        
        player.GetStats();

    }

    public override void BeginCooldown(GameObject parent)
    {
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();

        switch(statname)
        {
            case Statname.vitallity:
                player.MaxHp /= statBonusValue;
                break;
            case Statname.strength:
                player.strength /= statBonusValue;
                break;
            case Statname.abillity:
                player.magicPower /= statBonusValue;
                break;
            case Statname.agillity:
                player.agillity /= statBonusValue;
                break;
            case Statname.charisma:
                player.charisma /= statBonusValue;
                break;
            
        }
        
        player.GetStats();
    }
}
