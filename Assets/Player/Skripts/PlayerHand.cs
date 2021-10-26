using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum Rotations
    {
        Down = -90,
        Up = 90,
        Left = -180,
        Right = 0,
        UpLeft = 45,
        UpRight = 135,
        DownLeft = -135,
        DownRight = -45,
    }

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

            childSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
            ChangeChildSpriteOrder(childSprite);
        }

        public void RotateHand(Rotations rotations)
        {
            int degree = (int)rotations;
            transform.eulerAngles = Vector3.forward * degree;
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
