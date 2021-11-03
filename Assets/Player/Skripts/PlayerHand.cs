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

        public EquipableWeapon.Weapon currentWeapon
        {
            get => GetComponentInChildren<EquipableWeapon.Weapon>();
        }


        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.localPosition;
            childSprite = GetComponentInChildren<SpriteRenderer>();
            childSprite.gameObject.layer = 9;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeWeapon(GameObject weaponToEquip)
        {
            GameObject currentWeapon = childSprite.gameObject;

            //Detach
            currentWeapon.layer = 8;
            currentWeapon.transform.parent = null;
            currentWeapon.transform.position = weaponToEquip.transform.position;
            childSprite.sortingOrder = 1;

            //Attach
            weaponToEquip.layer = 9;
            childSprite = weaponToEquip.GetComponent<SpriteRenderer>();
            weaponToEquip.transform.parent = transform;
            weaponToEquip.transform.localPosition = Vector3.zero;
        }

        public void RotateHand(Rotations rotations)
        {
            int degree = (int) rotations;
            childSprite.sortingOrder = 5;
            childSprite.flipY = false;
            if (rotations == Rotations.Down)
            {
                childSprite.flipY = true;
                childSprite.transform.eulerAngles = Vector3.forward * -90f;
                transform.localPosition = startPos + new Vector3(0.1f, 0, 0);
            }
            else if (rotations == Rotations.DownLeft)
            {
                childSprite.flipY = true;
                childSprite.transform.eulerAngles = Vector3.forward * -135;
                transform.localPosition = startPos + new Vector3(0.2f, 0, 0);
            }
            else if (rotations == Rotations.Left)
            {
                childSprite.flipY = true;
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * 180;
                transform.localPosition = startPos + new Vector3(0.4f, 0, 0);
            }
            else if (rotations == Rotations.UpLeft)
            {
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * 135f;
                transform.localPosition = startPos + new Vector3(0.4f, 0, 0);
            }
            else if (rotations == Rotations.Up)
            {
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * 90f;
                transform.localPosition = startPos + new Vector3(0.8f, 0, 0);
            }
            else if (rotations == Rotations.UpRight)
            {
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * 45f;
                transform.localPosition = startPos + new Vector3(0.6f, 0, 0);
            }
            else if (rotations == Rotations.Right)
            {
                childSprite.transform.eulerAngles = Vector3.forward * 0;
                transform.localPosition = startPos + new Vector3(0.3f, 0, 0);
            }
            else if (rotations == Rotations.DownRight)
            {
                childSprite.transform.eulerAngles = Vector3.forward * -20;
                transform.localPosition = startPos + new Vector3(0.1f, 0, 0);
            }
        }
    }
}