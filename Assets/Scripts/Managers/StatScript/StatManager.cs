using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; } 
    
    private Dictionary<StatTypeSO, float> statAmountDictionary;

    //Initialisations without external dependancy on Awake / with external dependancy on Start
    private void Awake()
    {
        Instance = this;
        //holds Type and Value of Resource
        statAmountDictionary = new Dictionary<StatTypeSO, float>();

        StatTypeListSO statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);

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
        statAmountDictionary[statType] += amount;
    }
    
    //Adds Resource of a Type with a Amount
    public void RemoveStat(StatTypeSO statType, float amount)
    {
        statAmountDictionary[statType] -= amount;
    }
}
