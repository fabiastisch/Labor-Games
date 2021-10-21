using UnityEngine;
using UnityEngine.EventSystems;

namespace LevelingAndClasses.ClassFolder
{
    public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Canvas canvas;
        public static DragDrop Instance { get; private set; }
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        //private SkillsAndPassives skillsAndPassives;
        private Vector3 defaultPos;
        public bool droppedOnSlot;

        void Start()
        {
            defaultPos = transform.position;
        }

        private void Awake()
        {
            Instance = this;
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            defaultPos = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
            eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = false;
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("PointerDown");
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
        
            if (droppedOnSlot == false)
            {
                transform.position = defaultPos;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            //throw new NotImplementedException();
        }

        /*public SkillsAndPassives GetSkillsAndPassives()
    {
        return GetComponent<SkillAndPassiveList>().GetSkillsAndPassives();
    }

    public void SetSkillsAndPassives(SkillsAndPassives skillsAndPassives)
    {
        this.skillsAndPassives = skillsAndPassives;
    }*/
    }
}
