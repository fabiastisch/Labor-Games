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
        private Vector3 defaultPos;

        private bool restricted = false;

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

        //Todo connect with Classslot / remove current passiveSlot
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!restricted)
            {
                //Debug.Log("OnBeginDrag");
                canvasGroup.alpha = .6f;
                canvasGroup.blocksRaycasts = false;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //Debug.Log("PointerDown");
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!restricted)
            {
                rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!restricted)
            {
                //Debug.Log("OnEndDrag");
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
                transform.position = defaultPos;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            //throw new NotImplementedException();
        }

        public void setRestricted()
        {
            restricted = true;
        }
        
        public void notRestricted()
        {
            restricted = false;
        }
    }
}