using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Passive : ScriptableObject
{
   public new string name;
   public float cooldown;
   public float activeTime;
   public string description;
   public bool allTheTimeActive;
   public float repeatingNumber;
   public float firstActivationForRepeat;
   public PassiveSlot.PassiveState passiveState;

   public virtual void Activation(GameObject parent)
   {
   }
   public virtual void BeginCooldown(GameObject parent)
   {
      
   }
}
