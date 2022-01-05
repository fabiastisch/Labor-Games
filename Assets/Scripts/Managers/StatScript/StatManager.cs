using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; } 
    
    private Dictionary<StatTypeSO, float> statAmountDictionary;

    public StatTypeListSO statTypeList;
    
    public event Action StatChanged;
    
    public void InvokeOnStatChanged () => StatChanged?.Invoke();

    //Initialisations without external dependancy on Awake / with external dependancy on Start
    private void Awake()
    {
        Instance = this;
        //holds Type and Value of Resource
        statAmountDictionary = new Dictionary<StatTypeSO, float>();

        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);

        //each resource starts with Amount 0;
        foreach (StatTypeSO statType in statTypeList.list)
        {
            statAmountDictionary[statType] = 0;
        }
    }

    //Shows Values of each Type
    private void TestLogStatAmountDictionary()
    {
        foreach (StatTypeSO statType in statAmountDictionary.Keys)
        {
            Debug.Log(statType.nameString + ": " + statAmountDictionary[statType]);
        }
    }

    //Adds Resource of a Type with a Amount
    public void AddStat(StatTypeSO statType, float amount)
    {
        //Debug.Log(statType.nameString + ": " + statAmountDictionary[statType]);
        statAmountDictionary[statType] += amount;
        InvokeOnStatChanged();
    }
    
    //Adds Resource of a Type with a Amount
    public void RemoveStat(StatTypeSO statType, float amount)
    {
        statAmountDictionary[statType] -= amount;
        InvokeOnStatChanged();
    }

    public void MultiplyStat(StatTypeSO statType, float amount)
    {
        statAmountDictionary[statType] *= amount;
        InvokeOnStatChanged();
    }
    
    public void DivideStat(StatTypeSO statType, float amount)
    {
        statAmountDictionary[statType] /= amount;
        InvokeOnStatChanged();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StatTypeListSO list = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
            TestLogStatAmountDictionary();
        }
    }

    public float GetStat(StatTypeSO statType)
    {
        return statAmountDictionary[statType];
    }

    public bool GetBool(int numberOfStatType)
    {
        StatTypeSO statTyp = statTypeList.list[numberOfStatType];
        if (statTyp.hasBoolValue)
        {
            return statTyp.boolValue;
        }

        return false;
    }

    public void SetBool(int numberOfStatType)
    {
        StatTypeSO statTyp = statTypeList.list[numberOfStatType];

        if (statTyp.hasBoolValue)
        {
            statTyp.boolValue = true;
        }
    }
    
    public void RemoveBool(int numberOfStatType)
    {
        StatTypeSO statTyp = statTypeList.list[numberOfStatType];

        if (statTyp.hasBoolValue)
        {
            statTyp.boolValue = false;
        }
    }
    
    
}
