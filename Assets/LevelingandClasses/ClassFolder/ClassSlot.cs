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
        public PointerEventData returnData;
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("skillsAndPassives.GetType()");
        Debug.Log("On Drop + " + eventData.pointerDrag.gameObject + " | " + gameObject.name);
        
        SkillsAndPassives skillsAndPassives = eventData.pointerDrag.GetComponent<SkillAndPassiveList>()
            .GetSkillsAndPassives();
        //Debug.Log(skillsAndPassives);
        Debug.Log(skillsAndPassives.skillsAndPassivesType);
        OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs {skillsAndPassives = skillsAndPassives, returnData = eventData} );
    }
    
}
