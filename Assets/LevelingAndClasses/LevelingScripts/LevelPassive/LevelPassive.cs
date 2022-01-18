using UnityEngine;

[CreateAssetMenuAttribute(menuName = "ScriptableObject/LevelPassive")]
public class LevelPassive : ScriptableObject
{
    //Basic Class for Passives
    public new string name;
    public LevelPassiveType levelPassiveType;

    public LevelPassiveCondition.LevelPassiveConditionType conditionType =
        LevelPassiveCondition.LevelPassiveConditionType.None;

    public ClassEnum.Classes classType = ClassEnum.Classes.None;

    public SkillsAndPassivesType typeForUI = SkillsAndPassivesType.None;

    public enum LevelPassiveType
    {
       SingleTime,
       Repeat,
       Condition
    }

    //if needed for Passive
    public Sprite classPassiveIcon;
    
    public float cooldownMaxTime;

    public bool hasActiveTime;
    public float activeMaxTime;
    
    public string description;

    public float conditionTime;
    public PassiveSlot.PassiveState passiveState;
    public Sprite passiveImage;


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