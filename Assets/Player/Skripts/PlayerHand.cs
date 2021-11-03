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
        private Vector3 childPos;


        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.localPosition;
            childSprite = GetComponentInChildren<SpriteRenderer>();
            childSprite.gameObject.layer = 9;
            childPos = childSprite.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void ChangeWeapon(GameObject weaponToEquip)
        {
            GameObject currentWeapon = childSprite.gameObject;
            Debug.Log("Interact");
            //Detach
            currentWeapon.layer = 8;
            currentWeapon.transform.parent = null;
            currentWeapon.transform.position = weaponToEquip.transform.position;
            childSprite.sortingOrder = 1;

            //Attach
            weaponToEquip.layer = 9;
            childSprite = weaponToEquip.GetComponent<SpriteRenderer>();
            weaponToEquip.transform.parent = transform;
            weaponToEquip.transform.position = childPos;

        }

        public void RotateHand(Rotations rotations)
        {
            int degree = (int) rotations;
            childSprite.sortingOrder = 5;

            if (rotations == Rotations.Down)
            {
                childSprite.flipX = true;
                childSprite.transform.eulerAngles = Vector3.forward * 90f;
                transform.localPosition = startPos + new Vector3(0.1f, 0, 0);
            }
            else if (rotations == Rotations.DownLeft)
            {
                childSprite.flipX = true;
                childSprite.transform.eulerAngles = Vector3.forward * 20;
                transform.localPosition = startPos + new Vector3(0.2f, 0, 0);
            }
            else if (rotations == Rotations.Left)
            {
                childSprite.flipX = true;
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * 0;
                transform.localPosition = startPos + new Vector3(0.4f, 0, 0);
            }
            else if (rotations == Rotations.UpLeft)
            {
                childSprite.flipX = true;
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * -45f;
                transform.localPosition = startPos + new Vector3(0.4f, 0, 0);
            }
            else if (rotations == Rotations.Up)
            {
                childSprite.flipX = false;
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * 90f;
                transform.localPosition = startPos + new Vector3(0.8f, 0, 0);
            }
            else if (rotations == Rotations.UpRight)
            {
                childSprite.flipX = false;
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * 45f;
                transform.localPosition = startPos + new Vector3(0.6f, 0, 0);
            }
            else if (rotations == Rotations.Right)
            {
                childSprite.flipX = false;
                childSprite.transform.eulerAngles = Vector3.forward * 0;
                transform.localPosition = startPos + new Vector3(0.3f, 0, 0);
            }
            else if (rotations == Rotations.DownRight)
            {
                childSprite.flipX = false;
                childSprite.transform.eulerAngles = Vector3.forward * -20;
                transform.localPosition = startPos + new Vector3(0.1f, 0, 0);
            }
        }
    }
}