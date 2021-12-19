using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPassiveCondition : MonoBehaviour
{
    private LevelPassiveConditionType type;
    public enum LevelPassiveConditionType
    {
        DidCrit,
        Movement,
        StandStill,
        KilledEnemy,
        RecievedDmg,
        None
    }

}
