using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Manager/StatType")]
public class StatTypeSO : ScriptableObject
{
    public string nameString;

    public bool hasBoolValue = false;

    public bool boolValue = false;

    private void Awake()
    {
        if (boolValue == true)
        {
            hasBoolValue = true;
        }
    }

    public void BoolIsTrue()
    {
        if (hasBoolValue == true)
        {
            boolValue = true;
        }
    }
    
    public void BoolIsFalse()
    {
        if (hasBoolValue == true)
        {
            boolValue = false;
        }
    }
}
