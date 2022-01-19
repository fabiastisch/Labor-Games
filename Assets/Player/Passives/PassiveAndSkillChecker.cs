using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PassiveAndSkillChecker : MonoBehaviour
{
    [Header("SpellSlotted")] [SerializeField]
    private List<Spell> spellList = new List<Spell>();

    [Header("PassiveSlotted")] [SerializeField]
    private List<LevelPassive> passiveList = new List<LevelPassive>();

    [Header("ClassType")] [SerializeField]
    private List<ClassEnum.Classes> classTypeList = new List<ClassEnum.Classes>();

    [Header("NameObjects")] [SerializeField]
    private List<GameObject> nameObjectList = new List<GameObject>();
    
    [Header("SpellCasterObjects")] [SerializeField]
    private List<SpellCaster> spellCasterList = new List<SpellCaster>();
    
    [Header("PassiveHolder")] [SerializeField]
    private List<LevelPassiveListChecker> levelPassiveListCheckerList = new List<LevelPassiveListChecker>();

    public static PassiveAndSkillChecker Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        classTypeList[0] = ClassEnum.Classes.None;
        classTypeList[1] = ClassEnum.Classes.None;
    }

    /**
     * Adds Item to number Position, left is 0 and last is 5 (5 would be Hidden Active)
     */
    public void AddActiveToList(int number, PassiveAndActiveSlot itemToAdd)
    {
        if (spellList.Count <= 0)
        {
            return;
        }

        spellList[number] = itemToAdd.spell;
        spellCasterList[number].AddSpell(itemToAdd.spell);
        UpdateForTypesInLists();
    }

    /**
     * Adds Item to number Position, left is 0 and last is 6 (6 would be Hidden Passive)
     */
    public void AddPassiveToList(int number, PassiveAndActiveSlot itemToAdd)
    {
        if (passiveList.Count <= 0)
        {
            return;
        }

        passiveList[number] = itemToAdd.passive;
        levelPassiveListCheckerList[number].AddLevelPassive(itemToAdd.passive);
        UpdateForTypesInLists();
    }

    public bool CheckSpellListForDublicate(PassiveAndActiveSlot itemToAdd)
    {
        foreach (var item in spellList)
        {
            if (item != null)
            {
                if (item.Equals(itemToAdd.spell))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool CheckPassiveListForDublicate(PassiveAndActiveSlot itemToAdd)
    {
        foreach (var item in passiveList)
        {
            if (item != null)
            {
                if (item.Equals(itemToAdd.passive))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void RemovePassive(int number)
    {
        passiveList[number] = null;
        levelPassiveListCheckerList[number].RemovePassive();
        UpdateForTypesInLists();
    }

    public void RemoveActive(int number)
    {
        spellList[number] = null;
        spellCasterList[number].RemoveSpell();
        UpdateForTypesInLists();
    }

    public void AddTypeToList(ClassEnum.Classes type)
    {
        if (classTypeList.Any())
        {
            if (classTypeList[0] == ClassEnum.Classes.None)
            {
                classTypeList[0] = type;
                nameObjectList[0].GetComponent<Text>().text = type.ToString();
            }

            else if (classTypeList[1] == ClassEnum.Classes.None)
            {
                classTypeList[1] = type;
                nameObjectList[1].GetComponent<Text>().text = type.ToString();
            }
        }
    }


    public bool CheckForTypeInList(ClassEnum.Classes type)
    {
        if (classTypeList.Any())
        {
            if (classTypeList[0] == ClassEnum.Classes.None || classTypeList[0] == type)
            {
                return true;
            }

            else if (classTypeList[1] == ClassEnum.Classes.None || classTypeList[1] == type)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    private void RemoveTypeFromList(ClassEnum.Classes type)
    {
        if (classTypeList.Any())
        {
            if (classTypeList[0] == type)
            {
                classTypeList[0] = ClassEnum.Classes.None;
            }

            else if (classTypeList[1] == type)
            {
                classTypeList[0] = ClassEnum.Classes.None;
            }
        }
    }

    private void UpdateForTypesInLists()
    {
        ClassEnum.Classes class1 = ClassEnum.Classes.None;
        ClassEnum.Classes class2 = ClassEnum.Classes.None;

        foreach (var spell in spellList)
        {
            if (spell != null)
            {
                if (spell.classType != ClassEnum.Classes.None)
                {
                    if (class1 == ClassEnum.Classes.None || class1.Equals(spell.classType))
                    {
                        class1 = spell.classType;
                    }
                    else if (class2 == ClassEnum.Classes.None || class2.Equals(spell.classType))
                    {
                        class2 = spell.classType;
                    }
                }
            }
        }

        foreach (var passive in passiveList)
        {
            if (passive != null)
            {
                if (passive.classType != ClassEnum.Classes.None)
                {
                    if (class1 == ClassEnum.Classes.None || class1.Equals(passive.classType))
                    {
                        class1 = passive.classType;
                    }
                    else if (class2 == ClassEnum.Classes.None || class2.Equals(passive.classType))
                    {
                        class2 = passive.classType;
                    }
                }
            }
        }

        classTypeList[0] = class1;
        nameObjectList[0].GetComponent<Text>().text = class1.ToString();
        classTypeList[1] = class2;
        nameObjectList[1].GetComponent<Text>().text = class2.ToString();
    }

    /**
     * True needs to be Restricted, False is not Restricted
     * 
     */
    public bool CheckIfClassIsRestricted(ClassEnum.Classes type)
    {
        //Wenn Type noch frei ist false;
        if (classTypeList[0] == ClassEnum.Classes.None || classTypeList[1] == ClassEnum.Classes.None)
            return false;

        //Wenn der Type  Vorhanden ist false;
        if (classTypeList[0] == type || classTypeList[1] == type)
            return false;

        //Wenn nicht Frei und nicht Vorhanden
        return true;
    }

    public bool ActivateSpellInSlot(int number)
    {
        if (!spellCasterList.Any()||spellCasterList[number].spell.Equals(null))
        {
            return false;
        }
        spellCasterList[number].KeyActivated();
        return true;
    }
}