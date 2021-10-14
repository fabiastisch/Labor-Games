using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics
{
    public event EventHandler OnStatisticChange;
    public static int STAT_MIN = 0;
    public static int STAT_MAX = 100;

    public enum Type
    {
        Strength,
        Vitallity,
        Charisma,
        Abillity,
        Agillity,
    }
    private OneStat strengthStat, vitallityStat, charismaStat, abillityStat, agillityStat;

    public Statistics(int strengthStatAmount, int vitallityStatAmount,int charismaStatAmount, int abillityStatAmount, int agillityStatAmount)
    {
        strengthStat = new OneStat(strengthStatAmount);
        vitallityStat = new OneStat(vitallityStatAmount);
        charismaStat = new OneStat(charismaStatAmount);
        abillityStat = new OneStat(abillityStatAmount);
        agillityStat = new OneStat(agillityStatAmount);
    }

    private OneStat GetOneStat(Type statType)
    {
        switch (statType)
        {
                case Type.Strength: return strengthStat;
                case Type.Vitallity: return vitallityStat;
                case Type.Charisma: return charismaStat;
                case Type.Abillity: return abillityStat;
                case Type.Agillity: return agillityStat;
            default: 
                 return strengthStat;
        }
    }
    
    public void SetStatisticAmount(Type statType, int staticValue)
    {
        Debug.Log("SetStatisticAmount stat : " + statType + " and Value : " + staticValue);
       GetOneStat(statType).SetStatisticAmount(staticValue);
        if (OnStatisticChange != null) OnStatisticChange(this, EventArgs.Empty);
    }

    public void IncreaseStatAmount(Type statType)
    {
        SetStatisticAmount(statType, GetValue(statType) +1 );
        Debug.Log("Increased : " + statType);
    }
        
    public void DecreaseStatAmount(Type statType)
    {
        SetStatisticAmount(statType, GetValue(statType) -1 );
    }
        
    public int GetValue(Type statType)
    {
        return GetOneStat(statType).GetValue();
    }

    public float GetPersentageAmount(Type statType)
    {
        return GetOneStat(statType).GetPersentageAmount();
    }

    private class OneStat
    {
        private int stat;

        public OneStat(int statAmount)
        {
            SetStatisticAmount(statAmount);
        }
        
        public void SetStatisticAmount(int staticValue)
        {
            stat = Mathf.Clamp(staticValue, STAT_MIN, STAT_MAX);
        }

        public int GetValue()
        {
            return stat;
        }

        public float GetPersentageAmount()
        {
            return (float) stat / STAT_MAX;
        }
    }
    
}
