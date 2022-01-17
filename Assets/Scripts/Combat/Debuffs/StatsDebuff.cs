using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Manager/DebuffType/StatsDebuff")]
public class StatsDebuff : DebuffTypeSO
{
    [SerializeField] private StatTypeSO statType;
    public float prozentage;
    public bool shouldUseFlattValue;
    public float flatValue;

    //TODO: Needs to work on enemys
    public override void ChangeStats(Combat.Character character)
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

    }
}
