using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

public class ClassSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private SkillsAndPassivesType _type = SkillsAndPassivesType.ClassActive;
    [SerializeField] private GameObject image;

    public ClassEnum.Classes classSlotted = ClassEnum.Classes.None;

    private Sprite defaultSprite;

    [SerializeField] private int number = 0;

    //Only if it is passive
    [SerializeField] public LevelPassive passive;

    //Only if it is Active
    [SerializeField] public Spell spell;

    private void Start()
    {
        defaultSprite = transform.GetChild(0).GetComponent<Image>().sprite;
    }

    // Not used
    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;

    private SkillsAndPassivesType skillsAndPassives;


    public class OnItemDroppedEventArgs : EventArgs
    {
        public SkillsAndPassivesType skillsAndPassives;
        public PointerEventData returnData;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On Drop + " + eventData.pointerDrag.gameObject + " | " + gameObject.name);


        skillsAndPassives = eventData.pointerDrag.GetComponent<PassiveAndActiveSlot>().type;
        classSlotted = eventData.pointerDrag.GetComponent<PassiveAndActiveSlot>().classType;

        GameObject dragObject = eventData.pointerDrag.gameObject;


        Debug.Log(skillsAndPassives);

        if (skillsAndPassives == _type)
        {
            if (skillsAndPassives == SkillsAndPassivesType.ClassActive ||
                skillsAndPassives == SkillsAndPassivesType.HiddenActive)
            {
                if (PassiveAndSkillChecker.Instance.CheckForTypeInList(classSlotted) &&
                    !PassiveAndSkillChecker.Instance.CheckSpellListForDublicate(
                        dragObject.GetComponent<PassiveAndActiveSlot>()))
                {
                    PassiveAndSkillChecker.Instance.AddActiveToList(number,
                        dragObject.GetComponent<PassiveAndActiveSlot>());
                    //DragDrop dragdrop = eventData.pointerDrag.GetComponent<DragDrop>();
                    spell = dragObject.GetComponent<PassiveAndActiveSlot>().spell;
                    classSlotted = spell.classType;
                    transform.GetChild(0).GetComponent<Image>().sprite = spell.abitllityIcon;
                    transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
            }

            else if (skillsAndPassives == SkillsAndPassivesType.ClassPassive ||
                     skillsAndPassives == SkillsAndPassivesType.HiddenPassive)
            {
                if (PassiveAndSkillChecker.Instance.CheckForTypeInList(classSlotted) &&
                    !PassiveAndSkillChecker.Instance.CheckPassiveListForDublicate(
                        dragObject.GetComponent<PassiveAndActiveSlot>()))
                {
                    PassiveAndSkillChecker.Instance.AddPassiveToList(number,
                        dragObject.GetComponent<PassiveAndActiveSlot>());
                    if (passive != null)
                        passive.Removed(gameObject);
                    passive = dragObject.GetComponent<PassiveAndActiveSlot>().passive;
                    classSlotted = passive.classType;
                    transform.GetChild(0).GetComponent<Image>().sprite = passive.classPassiveIcon;
                    transform.GetChild(0).GetComponent<Image>().enabled = true;
                }
            }
        }

        //OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs {skillsAndPassives = skillsAndPassives, returnData = eventData} );
    }
    
    //used from Buttons to Reset the Classslot

    public void ResetSlot()
    {
        if (spell != null)
        {
            PassiveAndSkillChecker.Instance.RemoveActive(number);
        }
        else if (passive != null)
        {
            passive.Removed(gameObject);
            PassiveAndSkillChecker.Instance.RemovePassive(number);
        }
        
        spell = null;
        passive = null;
        classSlotted = ClassEnum.Classes.None;
        transform.GetChild(0).GetComponent<Image>().sprite = defaultSprite;
        transform.GetChild(0).GetComponent<Image>().enabled = false;
    }
}