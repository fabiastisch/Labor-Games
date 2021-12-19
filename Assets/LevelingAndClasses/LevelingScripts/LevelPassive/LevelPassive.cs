using System.Collections;
using System.Collections.Generic;
using LevelingAndClasses.ClassFolder;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenuAttribute(menuName = "ScriptableObject/LevelPassive")]
public class LevelPassive : ScriptableObject
{
    //Basic Class for Passives
    public new string name;
    public LevelPassiveType levelPassiveType;

    public enum LevelPassiveType
    {
       SingleTime,
       Repeat,
       Condition
    }
    
    public float cooldownMaxTime;
    public float activeMaxTime;
    public string description;
    public float repeatingMaxTime;
    public PassiveSlot.PassiveState passiveState;


    //Effect that happens if Activated
    public virtual void Activation(GameObject parent)
    {
    }
   
    //The Effect that Happen if the Abillity/Passive ends
    public virtual void BeginCooldown(GameObject parent)
    {
      
    }
    
    //The Effect that Happen if it gets Removed
    public virtual void Removed(GameObject parent)
    {
      
    }
    
    
}