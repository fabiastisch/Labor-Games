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
        private SpriteRenderer childSprite;
        private Vector3 startPos;


        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.localPosition;
            childSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void RotateHand(Rotations rotations)
        {
            int degree = (int) rotations;

            //Correct Swordorder
            if (degree <= 158 && degree >= 22)
            {
                childSprite.sortingOrder = 1;
            }
            else
            {
                childSprite.sortingOrder = 5;
            }

            if (rotations == Rotations.Down)
            {
                childSprite.transform.eulerAngles = Vector3.forward * -135f;
                transform.localPosition = startPos + new Vector3(0.1f, 0, 0);
            }
            else if (rotations == Rotations.DownLeft)
            {
                childSprite.transform.eulerAngles = Vector3.forward * 135f;
                transform.localPosition = startPos + new Vector3(0.2f, 0, 0);
            }
            else if (rotations == Rotations.Left)
            {
                childSprite.transform.eulerAngles = Vector3.forward * 135f;
                transform.localPosition = startPos + new Vector3(0.4f, 0, 0);
            }
            else if (rotations == Rotations.UpLeft)
            {
                childSprite.transform.eulerAngles = Vector3.forward * 135f;
                transform.localPosition = startPos + new Vector3(0.4f, 0, 0);
            }
            else if (rotations == Rotations.Up)
            {
                childSprite.transform.eulerAngles = Vector3.forward * 45f;
                transform.localPosition = startPos + new Vector3(0.8f, 0, 0);
            }
            else if (rotations == Rotations.UpRight)
            {
                childSprite.transform.eulerAngles = Vector3.forward * -45f;
                transform.localPosition = startPos + new Vector3(0.3f, 0, 0);
            }
            else if (rotations == Rotations.Right)
            {
                childSprite.transform.eulerAngles = Vector3.forward * -45f;
                transform.localPosition = startPos + new Vector3(0.3f, 0, 0);
            }
            else if (rotations == Rotations.DownRight)
            {
                childSprite.transform.eulerAngles = Vector3.forward * -45f;
                transform.localPosition = startPos + new Vector3(0.1f, 0, 0);
            }
        }
    }
}