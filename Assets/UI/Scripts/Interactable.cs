using System;
using UI.Text;
using UnityEngine;

namespace UI.Scripts
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private string text = "Interact";
        [SerializeField] public Vector3 position;
        private TextPopup currentTextPopup;
        protected bool isInteractable = true;

        public void Reset()
        {
            position = transform.position;
        }

        public void SetInteractable(bool active)
        {
            //Debug.Log(name + ": SetInteractable " + active);
            if (!isInteractable && active)
            {
                return;
            }

            if (!active)
            {
                SetUnInteractable();
                return;
            }

            if (currentTextPopup && active) return;

            var transform1 = transform;
            currentTextPopup = TextPopup.Create(transform1.position + position, transform1, text);
            // TODO: sorting order | layer
            currentTextPopup.GetTextMesh().sortingOrder = 5;
        }

        protected void SetUnInteractable()
        {
            if (currentTextPopup)
            {
                Destroy(currentTextPopup.gameObject);
            }

            currentTextPopup = null;
        }

        public void SetLayerInteractable(bool active)
        {
            gameObject.layer = active ? 8 : 0;
        }

        protected virtual void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(transform.position + position, 0.2f);
        }

        public virtual void Interact()
        {
        }
    }
}