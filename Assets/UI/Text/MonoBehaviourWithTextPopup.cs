using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UI.Text
{
    public class MonoBehaviourWithTextPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        protected bool onPointerEnter = false;

        protected TextUI _textUI;


        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            onPointerEnter = true;
        }
        public virtual void OnPointerExit(PointerEventData eventData)
        {
            onPointerEnter = false;
            if (_textUI)
            {
                Destroy(_textUI.gameObject);
            }
        }

        protected virtual void OnDisable()
        {
            if (_textUI)
            {
                Destroy(_textUI.gameObject);
            }
        }
    }
}