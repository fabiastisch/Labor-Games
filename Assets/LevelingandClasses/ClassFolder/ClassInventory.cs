using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassInventory
{
    private List<SkillsAndPassives> skillsAndPassivesList;

    public ClassInventory()
    {
        skillsAndPassivesList = new List<SkillsAndPassives>();
        
        AddSkillOrPassive(new SkillsAndPassives{skillsAndPassivesType = SkillsAndPassives.SkillsAndPassivesType.ClassActive});
        Debug.Log("Inventory: " + skillsAndPassivesList.Count);
    }

    public void AddSkillOrPassive(SkillsAndPassives skillsAndPassives)
    {
        skillsAndPassivesList.Add(skillsAndPassives);
    }
}
