using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkillsAndPassives
{
    public enum SkillsAndPassivesType
    {
        ClassPassive,
        ClassActive,
        HiddenActive,
        HiddenPassive,
    }

    public SkillsAndPassivesType skillsAndPassivesType;

    //For Purpose of using this Type of Class for ItemSystem
    // public Sprite GetSprite()
    // {
    //     switch (SkillsAndPassivesType)
    //     {
    //         default:
    //             case SkillsAndPassivesType.ClassActive: return ASSETOFTHATTYPE;
    //     }
    // }
}