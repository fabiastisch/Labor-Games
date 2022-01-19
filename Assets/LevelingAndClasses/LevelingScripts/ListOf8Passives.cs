using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListOf8Passives : MonoBehaviour
{
    [Header("Passive Active")] [SerializeField]
    private List<GameObject> passiveList = new List<GameObject>();

    private UnlockControll unlockControll;

    [Header("Passive Slots")] [SerializeField]
    private List<GameObject> passiveSlots = new List<GameObject>();
    
    [Header("Passive Slots2")] [SerializeField]
    private List<GameObject> passiveSlots2 = new List<GameObject>();
    
    [SerializeField]
    private List<GameObject> levelPassiveCollection = new List<GameObject>();
    
    public static ListOf8Passives Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        unlockControll = UnlockControll.Instance;
    }
    
    public void AddItemToList(GameObject listEntry)
    {
        int listEntryCount = 0 ;
        if(passiveList.Any())
            listEntryCount = passiveList.Count();
        if (passiveList.Any() && passiveList.Contains(listEntry))
        {
            return;
        }
        if (passiveList.Count < 8)
        {
            passiveList.Add(listEntry);
            AddSinglePassiveToCollection(listEntryCount);
            
        }
        if (passiveList.Count > 7)
            unlockControll.ListFullLock();
        
        FillSlotsWithList();
    }

    public void RemoveItem(GameObject listEntryToRemove)
    {
        if(passiveList.Contains(listEntryToRemove))
            passiveList.Remove(listEntryToRemove);
        FillSlotsWithList();
        if (passiveList.Count < 8)
        {
           unlockControll.ListFullUnLock();
        }
        //RemoveEveryEntryToGetTheNewSlot
        RemoveEveryPassiveInCollection();
        AddLevelPassiveToCollection();
    }

    public void ReadList()
    {
        foreach (var entry in passiveList)
        {
            //give Informations to Something else
        }
    }

    public void FillSlotsWithList()
    {
        //Debug.Log("FillSlotsWithList");
        int count = 0;
        
        if (!passiveList.Any())
        {
            RemoveEmtpySpaces(count);
            return;
        }

        //every Object in List
        foreach (var passiveInList in passiveList)
        {
            passiveSlots[count].GetComponent<PassiveListEntry>().SetPassiveSlotted(passiveInList);
            passiveSlots2[count].GetComponent<PassiveListEntry>().SetPassiveSlotted(passiveInList);
            count++;
        }
        RemoveEmtpySpaces(count);
        
        // foreach (var passiveSlot in passiveSlots)
        // {
        //     if (passiveList.Count <= count || count > 8)
        //     {
        //         return;
        //     }
        //     passiveSlot.GetComponent<PassiveListEntry>().SetPassiveSlotted(passiveList[count]);
        //     count++;
        // }
    }

    private void RemoveEmtpySpaces(int count)
    {
        for (int counter = count  ; counter < 8; counter++)
        {
            passiveSlots[count].GetComponent<PassiveListEntry>().RemoveSlotWithOutList();
            passiveSlots2[count].GetComponent<PassiveListEntry>().RemoveSlotWithOutList();
        }
    }

    //Gives Functionallity of Passive to Player
    private void AddLevelPassiveToCollection()
    {
        for (int counter = 0; counter < 8; counter++)
        {
            if(passiveList.Any())
                if(passiveList.Count > counter)
                    levelPassiveCollection[counter].GetComponent<LevelPassiveListChecker>().AddLevelPassive(passiveList[counter].GetComponent<Requirements>().levelPassive);
        }
    }
    
    private void RemoveEveryPassiveInCollection()
    {
        for (int counter = 0; counter < 8; counter++)
        {
            if(levelPassiveCollection[counter].GetComponent<LevelPassiveListChecker>().levelPassive != null)
                levelPassiveCollection[counter].GetComponent<LevelPassiveListChecker>().RemovePassive();
        }
    }

    private void AddSinglePassiveToCollection(int count)
    {
        Debug.Log("Add slot Count: " + count);
        levelPassiveCollection[count].GetComponent<LevelPassiveListChecker>().AddLevelPassive(passiveList[count].GetComponent<Requirements>().levelPassive);
    }
    
    
}
