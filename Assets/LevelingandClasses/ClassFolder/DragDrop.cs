using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    public static DragDrop Instance { get; private set; }
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private SkillsAndPassives skillsAndPassives;

    private void Awake()
    {
        Instance = this;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
        if (rectTransform.GetComponent<SkillAndPassiveList>() != null)
        {
            Debug.Log("item " + rectTransform.GetComponent<SkillAndPassiveList>().GetSkillsAndPassives().skillsAndPassivesType);
            SetSkillsAndPassives(rectTransform.GetComponent<SkillAndPassiveList>().GetSkillsAndPassives());
            Debug.Log("Skill or Passive aquired");
            
        }
        else
            Debug.Log("No Skill or Passive");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public SkillsAndPassives GetSkillsAndPassives()
    {
        return skillsAndPassives;
    }

    public void SetSkillsAndPassives(SkillsAndPassives skillsAndPassives)
    {
        this.skillsAndPassives = skillsAndPassives;
    }
}
