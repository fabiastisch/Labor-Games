using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerHand : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        private SpriteRenderer childSprite;
        private Vector2 rotateDirection;

        private Vector2 MousePosition
        {
            get
            {
                Vector2 mouseOnScreen = cam.ScreenToWorldPoint(Input.mousePosition);
                return (mouseOnScreen - (Vector2)transform.position).normalized;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RotateHand();
            childSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
            ChangeChildSpriteOrder(childSprite);
        }

        private void RotateHand()
        {
            transform.up = MousePosition;
        }

        private void ChangeChildSpriteOrder(SpriteRenderer spriteRenderer)
        {
            if (MousePosition.y > 0.5)
            {
                spriteRenderer.sortingOrder = 1;
            }
            else
            {
                spriteRenderer.sortingOrder = 5;
            }
        }

    }
}
