using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ActualStatsThatGetUsed : MonoBehaviour
{
    public static ActualStatsThatGetUsed Instance { get; private set; }
    
    public float actualAttack,
        actualAbillityPower,
        actualAttackspeed,
        actualCharmChance,
        actualCritChance,
        actualCritDmgMultiplyer,
        actualEvadeChance,
        actualLifesteal,
        actualSpellVamp,
        actualMovementspeed,
        actualHP,
        actualStunChance,
        actualOmniVamp,
        actualCooldownReduction;

    [Header("ValueField")] [SerializeField]
    private List<GameObject> listOfName;

    private Dictionary<String, float> statList = new Dictionary<string, float>();

    public void CalculateAttack()
    {
        actualAttack = CalculateActualBigStat(1, 19, -1);
    }

    public void CalculateAbillity()
    {
        actualAbillityPower = CalculateActualBigStat(0, 18, -1);
    }

    public void CalculateMovement()
    {
        actualMovementspeed = CalculateActualBigStat(9, 23, -1);
    }

    public void CalculateAttackspeed()
    {
        actualAttackspeed = CalculateActualBigStat(2, 24, -1);
    }

    public void CalculateHP()
    {
        actualHP = CalculateActualBigStat(8, 25, 26);
    }

    public void CalculateSpellVamp()
    {
        actualSpellVamp = CalculateActualMicroStat(12);
    }
    
    public void CalculateOmniVamp()
    {
        actualOmniVamp = CalculateActualMicroStat(11);
    }
    
    public void CalculateLifeSteal()
    {
        actualLifesteal = CalculateActualMicroStat(7);
    }

    public void CalculateEvadeChance()
    {
        actualEvadeChance = CalculateActualMicroStat(6);
    }

    public void CalculateCooldownReduction()
    {
        actualCooldownReduction = CalculateActualMicroStat(4);
    }

    public void CalculateCharmChance()
    {
        actualCharmChance = CalculateActualMicroStat(3);
    }

    public void CalculateStunChance()
    {
        actualStunChance = CalculateActualMicroStat(10);
    }

    public void CalculateCrit()
    {
        StatManager statManager = StatManager.Instance;
        float crit = statManager.GetStat(statManager.statDic[StatType.CriticalChance]);
        float critMultiplyer = statManager.GetStat(statManager.statDic[StatType.CritChanceMultiplyer]);
        if (critMultiplyer == 0)
        {
            if (crit > 100)
            {
                actualCritChance = 100;
            }
            else
                actualCritChance = crit;
        }
        else
        {
            if (crit * critMultiplyer > 100)
            {
                actualCritChance = 100;
            }
            else
                actualCritChance = crit * critMultiplyer;
        }
    }

    public void CalculateCritMultiPlyer()
    {
        actualCritDmgMultiplyer = CalculateActualMicroStat(21);
    }
    
    private void Awake()
    {
        Instance = this;
        statList.Add("MaxHP :", actualHP );
        statList.Add("Attack :", actualAttack );
        statList.Add("AbillityPower :", actualAbillityPower );
        statList.Add("Attackspeed :", actualAttackspeed );
        statList.Add("Movementspeed :", actualMovementspeed );
        statList.Add("Lifesteal :", actualLifesteal );
        statList.Add("OmniVamp :", actualOmniVamp );
        statList.Add("SpellVamp :", actualSpellVamp );
        statList.Add("StunChance :", actualStunChance );
        statList.Add("CharmChance :", actualCharmChance );
        statList.Add("CooldownReduction :", actualCooldownReduction );
        statList.Add("CritChance :", actualCritChance );
        statList.Add("CritMultiplyer :", actualCritDmgMultiplyer );
        statList.Add("EvadeChance :", actualEvadeChance );
    }

    private void Start()
    {
        StatChanged();
    }

    public void StatChanged()
    {
        CalculateAbillity();
        CalculateAttack();
        CalculateAttackspeed();
        CalculateMovement();
        CalculateHP();
        CalculateSpellVamp();
        CalculateOmniVamp();
        CalculateLifeSteal();
        CalculateLifeSteal();
        CalculateEvadeChance();
        CalculateCooldownReduction();
        CalculateCharmChance();
        CalculateStunChance();
        CalculateCrit();
        CalculateCritMultiPlyer();
        SetNameAndValue();

    }

    public void SetNameAndValue()
    {
        int counter = 0;
        List<String> names = new List<string>();
        List<float> values = new List<float>();

        foreach (var pair in statList)
        {
            names.Add(pair.Key);
            values.Add(pair.Value);
        }
        
        foreach (var uiObject in listOfName)
        {
            Text name = uiObject.transform.GetChild(0).GetComponent<Text>();
            Text value = uiObject.transform.GetChild(1).GetComponent<Text>();

            if (statList.Any() && statList.Count > counter)
            {
                uiObject.SetActive(true);
                name.text = names[counter];
                value.text = values[counter].ToString();
            }
            else
            {
                uiObject.SetActive(false);
            }
            counter += 1;
        }
    }





    private float CalculateActualBigStat(int NumberOfBaseStat, int NumberOfBonusStat, int MultiplyerBonus)
    {
        float basePower = StatManager.Instance.GetStat(StatManager.Instance.statTypeList.list[NumberOfBaseStat]);
        float bonus = StatManager.Instance.GetStat(StatManager.Instance.statTypeList.list[NumberOfBonusStat]);
        if (MultiplyerBonus != -1)
        {
            float multiplyer = StatManager.Instance.GetStat(StatManager.Instance.statTypeList.list[MultiplyerBonus]);
            return (basePower + bonus) + (basePower + bonus) * multiplyer;
        }
        else
        {
            return basePower + bonus;
        }
    }
    
    private float CalculateActualSmallStat(int NumberOfBaseStat, int NumberOfBonusStat)
    {
        float basePower = StatManager.Instance.GetStat(StatManager.Instance.statTypeList.list[NumberOfBaseStat]);
        float bonus = StatManager.Instance.GetStat(StatManager.Instance.statTypeList.list[NumberOfBonusStat]);
        return basePower + bonus;
    }
    
    private float CalculateActualMicroStat(int NumberOfBaseStat)
    {
        return  StatManager.Instance.GetStat(StatManager.Instance.statTypeList.list[NumberOfBaseStat]);
    }
}