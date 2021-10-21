using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LevelingAndClasses.ClassFolder
{
    public class ClassSlot : MonoBehaviour, IDropHandler
    {
        [SerializeField]
        private SkillsAndPassives.SkillsAndPassivesType _type = SkillsAndPassives.SkillsAndPassivesType.ClassActive;

        // Not used
        public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;

        private SkillsAndPassives skillsAndPassives;


        public class OnItemDroppedEventArgs : EventArgs
        {
            public SkillsAndPassives skillsAndPassives;
            public PointerEventData returnData;
        }

        public void OnDrop(PointerEventData eventData)
        {
            //Debug.Log("skillsAndPassives.GetType()");
            Debug.Log("On Drop + " + eventData.pointerDrag.gameObject + " | " + gameObject.name);

            skillsAndPassives = eventData.pointerDrag.GetComponent<SkillAndPassiveList>()
                .GetSkillsAndPassives();
            Debug.Log(skillsAndPassives.skillsAndPassivesType);
            
            if (skillsAndPassives.skillsAndPassivesType == _type)
            {
                eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = true;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    GetComponent<RectTransform>().anchoredPosition;
            }


            //OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs {skillsAndPassives = skillsAndPassives, returnData = eventData} );
        }
    }
}