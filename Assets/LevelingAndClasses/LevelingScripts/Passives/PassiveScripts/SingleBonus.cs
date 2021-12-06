using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "SingleBonus", menuName = "Passives/SingleBonus")]
public class SingleBonus : Passive
{
    [SerializeField] private float statBonusValue = 1.5f;
    
    private StatTypeListSO statTypeList;
    private enum Statname{
        vitallity,
        strength,
        abillity,
        agillity,
        charisma,
    }

    [SerializeField] private Statname statname;
    
    private void Awake()
    { 
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }
    public override void Activation(GameObject parent)
    {
        //PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();

        switch(statname)
        {
            case Statname.vitallity:
                StatManager.Instance.MultiplyStat(statTypeList.list[8], statBonusValue);//MaxHp
                //player.MaxHp *= statBonusValue;
                break;
            case Statname.strength:
                StatManager.Instance.MultiplyStat(statTypeList.list[1], statBonusValue);//AttackScaling
                //player.strength *= statBonusValue;
                break;
            case Statname.abillity:
                StatManager.Instance.MultiplyStat(statTypeList.list[0], statBonusValue);//AbillityScaling
                //player.magicPower *= statBonusValue;
                break;
            case Statname.agillity:
                StatManager.Instance.MultiplyStat(statTypeList.list[9], statBonusValue);//Movementspeed
                //player.agillity *= statBonusValue;
                break;
            case Statname.charisma:
                StatManager.Instance.MultiplyStat(statTypeList.list[13], statBonusValue);//Charisma
                //player.charisma *= statBonusValue;
                break;
            
        }
        
        //player.GetStats();

    }

    public override void BeginCooldown(GameObject parent)
    {
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();

        switch(statname)
        {
            case Statname.vitallity:
                StatManager.Instance.DivideStat(statTypeList.list[8], statBonusValue);//MaxHp
                //player.MaxHp /= statBonusValue;
                break;
            case Statname.strength:
                StatManager.Instance.DivideStat(statTypeList.list[1], statBonusValue);//AttackScaling
                //player.strength /= statBonusValue;
                break;
            case Statname.abillity:
                StatManager.Instance.DivideStat(statTypeList.list[0], statBonusValue);//AbillityScaling
                //player.magicPower /= statBonusValue;
                break;
            case Statname.agillity:
                StatManager.Instance.DivideStat(statTypeList.list[9], statBonusValue);//Movementspeed
                //player.agillity /= statBonusValue;
                break;
            case Statname.charisma:
                StatManager.Instance.DivideStat(statTypeList.list[13], statBonusValue);//Charisma
                //player.charisma /= statBonusValue;
                break;
            
        }
        
        //player.GetStats();
    }
}
