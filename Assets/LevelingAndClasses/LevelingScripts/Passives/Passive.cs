using System.Collections;
using System.Collections.Generic;
using LevelingAndClasses.ClassFolder;
using UnityEngine;
public class Passive : ScriptableObject
{
   //Basic Class for Passives
   public new string name;
   public float cooldown;
   public float activeTime;
   public string description;
   public bool allTheTimeActive;
   public float repeatingSeconds;
   public float firstActivationForRepeat;
   public PassiveSlot.PassiveState passiveState;
   public SkillsAndPassivesType skillsAndPassivesType = SkillsAndPassivesType.ClassActive;

   //The Effect that Happen if you press a Button or the Passive Triggers
   public virtual void Activation(GameObject parent)
   {
   }
   
   //The Effect that Happen if the Abillity/Passive ends
   public virtual void BeginCooldown(GameObject parent)
   {
      
   }
}
