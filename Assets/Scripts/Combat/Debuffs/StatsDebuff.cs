using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;

[CreateAssetMenu(menuName = "ScriptableObject/Manager/DebuffType/StatsDebuff")]
public class StatsDebuff : DebuffTypeSO
{
    [SerializeField] private StatTypeSO statType;
    public float prozentage;
    public bool shouldUseFlattValue;
    public float flatValue;

    private Enemy enemy;
    private float reductionValue;

    public enum DebuffEnemyTyp
    {
        Snare,
        Stun,
        NoAttack,
        Slow,
        AttackspeedSlow,
    }


    //TODO: Needs to work on enemys
    /*
    public override void ChangeStats(Combat.Character character)
    {
        var myCharacter = character as Player.PlayerBase;

        if(myCharacter != null)
        {
            if (shouldUseFlattValue)
            {
                StatManager.Instance.RemoveStat(statType, flatValue);
            }
            else
            {
                StatManager.Instance.DivideStat(statType, prozentage);
            }
        }
        else
        {
            enemy = (Enemy)character;
            //reductionValue = shouldUseFlattValue == true ? flatValue : prozentage;
        }
       
    }

    public void Debuff()
    {
        if (shouldUseFlattValue)
        {
            StatManager.Instance.AddStat(statType, flatValue);
        }
        else
        {
            StatManager.Instance.MultiplyStat(statType, prozentage);
        }

    }*/
}
