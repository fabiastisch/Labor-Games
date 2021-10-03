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
            default:
                case Type.Strength: return strengthStat;
                case Type.Vitallity: return vitallityStat;
                case Type.Charisma: return charismaStat;
                case Type.Abillity: return abillityStat;
                case Type.Agillity: return agillityStat;
        }
    }
    
    public void SetStatisticAmount(Type statType, int StaticValue)
    {
       GetOneStat(statType).SetStatisticAmount(StaticValue);
        if (OnStatisticChange != null) OnStatisticChange(this, EventArgs.Empty);
    }

    public void IncreaseStatAmount(Type statType)
    {
        SetStatisticAmount(statType, GetValue(statType) +1 );
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
        
        public void SetStatisticAmount(int StaticValue)
        {
            stat = Mathf.Clamp(StaticValue, STAT_MIN, STAT_MAX);
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
