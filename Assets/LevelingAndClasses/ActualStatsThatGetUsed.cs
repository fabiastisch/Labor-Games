using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public enum ActualValues
    {
        actualAttack,
        actualAttackspeed,
        actualCharmChance,
        actualCritChance,
        actualCritDmgMultiplyer,
        actualEvadeChance,
        actualLifesteal,
        acutalSpellVamp,
        actualMovementspeed,
        actualHp,
        actualStunChance,
        actualOmniVamp,
        actualCooldownReduction,
        actualAbillityPower,
    }

    [Header("ValueField")] [SerializeField]
    private List<GameObject> listOfName;

    private Dictionary<String, VariableReference> statList = new Dictionary<string, VariableReference>();

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
        statList.Add("MaxHP :", new VariableReference(
            () => actualHP, // getter
            val => { actualHP = (float) val; } // setter
        ));
        statList.Add("Attack :", new VariableReference(
            () => actualAttack, // getter
            val => { actualAttack = (float) val; } // setter
        ));
        statList.Add("AbillityPower :", new VariableReference(
            () => actualAbillityPower, // getter
            val => { actualAbillityPower = (float) val; } // setter
        ));
        statList.Add("Attackspeed :", new VariableReference(
            () => actualAttackspeed, // getter
            val => { actualAttackspeed = (float) val; } // setter
        ));
        statList.Add("Movementspeed :", new VariableReference(
            () => actualMovementspeed, // getter
            val => { actualMovementspeed = (float) val; } // setter
        ));
        statList.Add("Lifesteal :", new VariableReference(
            () => actualLifesteal, // getter
            val => { actualLifesteal = (float) val; } // setter
        ));
        statList.Add("OmniVamp :", new VariableReference(
            () => actualOmniVamp, // getter
            val => { actualOmniVamp = (float) val; } // setter
        ));
        statList.Add("SpellVamp :", new VariableReference(
            () => actualSpellVamp, // getter
            val => { actualSpellVamp = (float) val; } // setter
        ));
        statList.Add("StunChance :", new VariableReference(
            () => actualStunChance, // getter
            val => { actualStunChance = (float) val; } // setter
        ));
        statList.Add("CharmChance :", new VariableReference(
            () => actualCharmChance, // getter
            val => { actualCharmChance = (float) val; } // setter
        ));
        statList.Add("CooldownReduction :", new VariableReference(
            () => actualCooldownReduction, // getter
            val => { actualCooldownReduction = (float) val; } // setter
        ));
        statList.Add("CritChance :", new VariableReference(
            () => actualCritChance, // getter
            val => { actualCritChance = (float) val; } // setter
        ));
        statList.Add("CritMultiplyer :", new VariableReference(
            () => actualCritDmgMultiplyer, // getter
            val => { actualCritDmgMultiplyer = (float) val; } // setter
        ));
        statList.Add("EvadeChance :", new VariableReference(
            () => actualEvadeChance, // getter
            val => { actualEvadeChance = (float) val; } // setter
        ));
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
            values.Add((float) pair.Value.Get());
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
        return StatManager.Instance.GetStat(StatManager.Instance.statTypeList.list[NumberOfBaseStat]);
    }

    public float ReturnValue(int valueName)
    {
        switch (valueName)
        {
            case 0:
                return actualAttack;
            case 1:
                return actualAttackspeed;
            case 2:
                return actualCharmChance;
            case 3:
                return actualCritChance;
            case 4:
                return actualCritDmgMultiplyer;
            case 5:
                return actualEvadeChance;
            case 6:
                return actualLifesteal;
            case 7:
                return actualSpellVamp;
            case 8:
                return actualMovementspeed;
            case 9:
                return actualHP;
            case 10:
                return actualStunChance;
            case 11:
                return actualOmniVamp;
            case 12:
                return actualCooldownReduction;
            case 13:
                return actualAbillityPower;
            
        }

        return 0f;
    }
}

sealed class VariableReference
{
    public Func<object> Get { get; private set; }
    public Action<object> Set { get; private set; }

    public VariableReference(Func<object> getter, Action<object> setter)
    {
        Get = getter;
        Set = setter;
    }
}