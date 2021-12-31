using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LevelingAndClasses.ClassFolder
{
    public class ClassSlot : MonoBehaviour, IDropHandler
    {
        [SerializeField]
        private SkillsAndPassivesType _type = SkillsAndPassivesType.ClassActive;
        [SerializeField]
        private GameObject image;

        public ClassEnum.Classes classSlotted = ClassEnum.Classes.None;
        
        //Only if it is passive
        [SerializeField]
        private Passive passive;
        
        //Only if it is Active
        [SerializeField]
        private Spell spell;

        // Not used
        public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;

        private SkillsAndPassivesType skillsAndPassives;

        private PassiveSlot passiveSlot;


        public class OnItemDroppedEventArgs : EventArgs
        {
            public SkillsAndPassivesType skillsAndPassives;
            public PointerEventData returnData;
        }

        public void OnDrop(PointerEventData eventData)
        {
            //Debug.Log("skillsAndPassives.GetType()");
            Debug.Log("On Drop + " + eventData.pointerDrag.gameObject + " | " + gameObject.name);

            skillsAndPassives = eventData.pointerDrag.GetComponent<PassiveSlot>().passive.skillsAndPassivesType;
                
            Debug.Log(skillsAndPassives);
            
            if (skillsAndPassives == _type)
            {
               DragDrop dragdrop = eventData.pointerDrag.GetComponent<DragDrop>();
               dragdrop.droppedOnSlot = true;
               dragdrop.classSlot = this;
               eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = 
                   GetComponent<RectTransform>().anchoredPosition;
               passiveSlot = eventData.pointerDrag.GetComponent<PassiveSlot>();
               passiveSlot.SetEquip();
               
            }


            //OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs {skillsAndPassives = skillsAndPassives, returnData = eventData} );
        }

        public Passive getPassive()
        {
            return passiveSlot.passive;
        }


        public void RemovePassiveSlot()
        {
            passiveSlot.SetEquip(false);
            passiveSlot = null;
        }
        
    }
}