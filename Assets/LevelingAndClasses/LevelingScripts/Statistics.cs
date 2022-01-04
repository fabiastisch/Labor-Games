using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics: MonoBehaviour
{
    public static Statistics Instance { get; private set; } 
    
    public event EventHandler OnStatisticChange;
    public static int STAT_MIN = 1;
    public static int STAT_MAX = 100;
    [SerializeField] private UnlockControll unlockControll;

    [SerializeField] [Range(1,100)]private int strengthStatAmount;
    [SerializeField] [Range(1,100)]private int vitallityStatAmount;
    [SerializeField] [Range(1,100)]private int charismaStatAmount;
    [SerializeField] [Range(1,100)]private int abillityStatAmount;
    [SerializeField] [Range(1,100)]private int agillityStatAmount;
    public enum Type
    {
        Strength,
        Vitallity,
        Charisma,
        Abillity,
        Agillity,
    }
    private OneStat strengthStat, vitallityStat, charismaStat, abillityStat, agillityStat;

    private void Awake()
    {
        Instance = this;
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

    public bool IncreaseStatAmount(Type statType)
    {
        if (GetValue(statType) == 100)
        {
            return false;
        }
        SetStatisticAmount(statType, GetValue(statType) +1 );
        Debug.Log("Increased : " + statType);
        unlockControll.CheckListForUnlocking();
        return true;
    }
        
    public bool DecreaseStatAmount(Type statType)
    {
        if (GetValue(statType) == 1)
        {
            return false;
        }
        SetStatisticAmount(statType, GetValue(statType) -1 );
        unlockControll.CheckListForUnlocking();
        return true;
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
