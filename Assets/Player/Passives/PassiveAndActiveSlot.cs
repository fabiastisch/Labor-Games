using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PassiveAndActiveSlot : MonoBehaviour
{
    public LevelPassive passive;
    public Spell spell;
    public Sprite sprite;
    public ClassEnum.Classes classType = ClassEnum.Classes.None;
    public SkillsAndPassivesType type = SkillsAndPassivesType.None;

    private bool disabledThroughClassRestriction;

    private void ChangeSprite()
    {
        if (spell != null)
        {
            sprite = spell.abitllityIcon;
        }

        else if (passive != null)
        {
            sprite = passive.classPassiveIcon;
        }

        this.GetComponent<Image>().sprite = sprite;
    }

    private void ChangeType()
    {
        if (spell != null)
        {
            type = spell.typeForUI;
            return;
        }

        if (passive != null)
        {
            type = passive.typeForUI;
        }
    }

    private void ChangeClassType(ClassEnum.Classes className)
    {
        classType = className;
    }

    public void ChangeParameter(ClassEnum.Classes className, Spell spellObject, LevelPassive passiveObject)
    {
        if (spellObject != null)
        {
            spell = spellObject;
        }
        else if (passiveObject != null)
        {
            passive = passiveObject;
        }
        
        ChangeSprite();
        ChangeType();
        ChangeClassType(className);
    }

    // public void IsRestricted()
    // {
    //     disabledThroughClassRestriction = true;
    // }
    //
    // public void NotRestricted()
    // {
    //     disabledThroughClassRestriction = false;
    // }
    //
    // public bool GetRestricted()
    // {
    //     return disabledThroughClassRestriction;
    // }
    
}