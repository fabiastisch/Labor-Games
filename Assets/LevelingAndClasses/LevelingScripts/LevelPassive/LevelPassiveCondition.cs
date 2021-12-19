using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPassiveCondition : MonoBehaviour
{
    private LevelPassiveConditionType conditionType;

    private float conditionDurationTimer;

    private float conditionMaxTime;

    private bool conditionDuration = false;
    private bool triggered = false;
    
    private LevelPassiveListChecker _levelPassiveListChecker;


    private void Start()
    {
        _levelPassiveListChecker = gameObject.GetComponent<LevelPassiveListChecker>();
    }
    
    
    public enum LevelPassiveConditionType
    {
        DidCrit,
        Movement,
        KilledEnemy,
        RecievedDmg,
        None
    }

    private void TimeConditionActivated()
    {
        triggered = true;
    }
    
    private void TimeConditionReset()
    {
        triggered = false;
        ResetConditionTime();
    }
    
    
    void Update()
    {
        if (conditionDuration)
        {
            if (triggered)
            {
                conditionDurationTimer -= Time.deltaTime;
                //after Time is over do something and restart Timer
                if (conditionDurationTimer <= 0f)
                {
                    _levelPassiveListChecker.TimeActivation();
                    ResetConditionTime();
                }
            }
        }
    }

    public void ResetConditionTime()
    {
        conditionDurationTimer = conditionMaxTime;
    }

    public void SetCondition(LevelPassiveConditionType type)
    {

        if (type == LevelPassiveConditionType.Movement)
        {
            conditionType = LevelPassiveConditionType.Movement;
            conditionDuration = true;
        }
        else if (type == LevelPassiveConditionType.DidCrit)
        {
            conditionType = LevelPassiveConditionType.DidCrit;
            conditionDuration = false;
        }
        else if (type == LevelPassiveConditionType.KilledEnemy)
        {
            conditionType = LevelPassiveConditionType.KilledEnemy;
            conditionDuration = false;
        }
        else if (type == LevelPassiveConditionType.RecievedDmg)
        {
            conditionType = LevelPassiveConditionType.RecievedDmg;
            conditionDuration = false;
        }
    }

    private void ActivateConditionDuration()
    {
        conditionDuration = true;
    }
    
    

    public void NoCondition()
    {
        conditionType = LevelPassiveConditionType.None;
        conditionDuration = false;
    }

    public void SetConditions(float conMaxTime, float conDurationTimer)
    {
        conditionDurationTimer = conDurationTimer;
        conditionMaxTime = conMaxTime;
    }
}
