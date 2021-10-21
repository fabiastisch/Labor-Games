using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAndPassiveList : MonoBehaviour
{
    private SkillsAndPassives skillsAndPassives;
    public SkillsAndPassives.SkillsAndPassivesType type = SkillsAndPassives.SkillsAndPassivesType.ClassActive;

    private void Awake()
    {
        skillsAndPassives = new SkillsAndPassives {skillsAndPassivesType = type};
    }

    public void SetSkillsAndPassives(SkillsAndPassives skillsAndPassives)
    {
        this.skillsAndPassives = skillsAndPassives;
    }

    public SkillsAndPassives GetSkillsAndPassives()
    {
        Debug.Log("GetSkillsAndPassives");
        return skillsAndPassives;
    }
}
