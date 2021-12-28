
using System;
using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/BonusStat")]
public class Vit3 : LevelPassive
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
        switch (statname)
        {
            case Statname.vitallity:
                StatManager.Instance.MultiplyStat(statTypeList.list[8], statBonusValue); //MaxHp
                //player.MaxHp *= statBonusValue;
                break;
            case Statname.strength:
                StatManager.Instance.MultiplyStat(statTypeList.list[1], statBonusValue); //AttackScaling
                //player.strength *= statBonusValue;
                break;
            case Statname.abillity:
                StatManager.Instance.MultiplyStat(statTypeList.list[0], statBonusValue); //AbillityScaling
                //player.magicPower *= statBonusValue;
                break;
            case Statname.agillity:
                StatManager.Instance.MultiplyStat(statTypeList.list[9], statBonusValue); //Movementspeed
                //player.agillity *= statBonusValue;
                break;
            case Statname.charisma:
                StatManager.Instance.MultiplyStat(statTypeList.list[13], statBonusValue); //Charisma
                //player.charisma *= statBonusValue;
                break;

        }
    }

    public override void BeginCooldown(GameObject parent)
    {
        switch (statname)
        {
            case Statname.vitallity:
                StatManager.Instance.DivideStat(statTypeList.list[8], statBonusValue); //MaxHp
                //player.MaxHp /= statBonusValue;
                break;
            case Statname.strength:
                StatManager.Instance.DivideStat(statTypeList.list[1], statBonusValue); //AttackScaling
                //player.strength /= statBonusValue;
                break;
            case Statname.abillity:
                StatManager.Instance.DivideStat(statTypeList.list[0], statBonusValue); //AbillityScaling
                //player.magicPower /= statBonusValue;
                break;
            case Statname.agillity:
                StatManager.Instance.DivideStat(statTypeList.list[9], statBonusValue); //Movementspeed
                //player.agillity /= statBonusValue;
                break;
            case Statname.charisma:
                StatManager.Instance.DivideStat(statTypeList.list[13], statBonusValue); //Charisma
                //player.charisma /= statBonusValue;
                break;

        }

    }
    
    public override void Removed(GameObject parent)
    {
        Debug.Log("Statname : " + nameof(statname) + "statTypeList : " + statTypeList + " Statmanager :" + StatManager.Instance );
        switch (statname)
        {
            case Statname.vitallity:
                StatManager.Instance.DivideStat(statTypeList.list[8], statBonusValue); //MaxHp
                //player.MaxHp /= statBonusValue;
                break;
            case Statname.strength:
                StatManager.Instance.DivideStat(statTypeList.list[1], statBonusValue); //AttackScaling
                //player.strength /= statBonusValue;
                break;
            case Statname.abillity:
                StatManager.Instance.DivideStat(statTypeList.list[0], statBonusValue); //AbillityScaling
                //player.magicPower /= statBonusValue;
                break;
            case Statname.agillity:
                StatManager.Instance.DivideStat(statTypeList.list[9], statBonusValue); //Movementspeed
                //player.agillity /= statBonusValue;
                break;
            case Statname.charisma:
                StatManager.Instance.DivideStat(statTypeList.list[13], statBonusValue); //Charisma
                //player.charisma /= statBonusValue;
                break;

        }

    }

}
