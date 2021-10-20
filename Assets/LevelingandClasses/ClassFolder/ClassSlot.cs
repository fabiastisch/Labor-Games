using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClassSlot : MonoBehaviour, IDropHandler
{
    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;

    public class OnItemDroppedEventArgs : EventArgs
    {
        public SkillsAndPassives skillsAndPassives;
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("skillsAndPassives.GetType()");
        SkillsAndPassives skillsAndPassives = DragDrop.Instance.GetSkillsAndPassives();
        Debug.Log(skillsAndPassives);
        // OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs {skillsAndPassives = skillsAndPassives});
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    GetComponent<RectTransform>().anchoredPosition;
        }
    }
    
}
