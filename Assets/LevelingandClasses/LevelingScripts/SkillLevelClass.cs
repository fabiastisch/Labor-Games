using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLevelClass : MonoBehaviour
{
    

    void unlockSkill(Spell spell, Statistics stats, PlayerEnum player)
    {
        if (spell.requirement.vitallityScore <= stats.GetValue(Statistics.Type.Vitallity))
        {
                 
        }
        if (spell.requirement.abillityScore <= stats.GetValue(Statistics.Type.Abillity))
        {
            
        }
        if (spell.requirement.agillityScore <= stats.GetValue(Statistics.Type.Agillity))
        {
            
        }
        if (spell.requirement.charimsaScore <= stats.GetValue(Statistics.Type.Charisma))
        {
            
        }
        if (spell.requirement.strengthScore <= stats.GetValue(Statistics.Type.Strength))
        {
            
        }

        if (spell.requirement.class1 == player.class1 || spell.requirement.class1 == ClassEnum.Classes.None)
        {
            
        }
        if (spell.requirement.class1 == player.class2 || spell.requirement.class1 == ClassEnum.Classes.None)
        {
            
        }
        
        
        
    }
}
