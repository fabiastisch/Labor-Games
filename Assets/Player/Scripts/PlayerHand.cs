using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using EquipableWeapon;
using Weapons.Effects;

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
        public EffectHandler effectHandler;
        private Weapon weapon;

        private bool isSword = true;
        private bool isBow = false;

        private const string PLAYERLAYER = "Player";
        private const string DEFAULTLAYER = "Default";

        public event Action OnWeaponChanged;


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
            weapon = GetComponentInChildren<Weapon>();
            effectHandler = weapon.GetComponent<EffectHandler>();
            OnWeaponChanged?.Invoke();
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
            childSprite.sortingLayerName = DEFAULTLAYER;

            //Attach
            weaponToEquip.layer = 9;
            childSprite = weaponToEquip.GetComponent<SpriteRenderer>();
            childSprite.sortingLayerName = PLAYERLAYER;
            weaponToEquip.transform.parent = transform;
            weaponToEquip.transform.localPosition = Vector3.zero;

            Weapon equippedWeaponweapon = currentWeapon.GetComponent<Weapon>();
            if (weapon.effect != null)
            {
                if (equippedWeaponweapon.effect != null)
                    equippedWeaponweapon.effect.Deactivate();
                if (equippedWeaponweapon.GetComponent<EffectHandler>())
                {
                    equippedWeaponweapon.GetComponent<EffectHandler>().state = EffectState.ready;

                }
                effectHandler = weaponToEquip.GetComponent<EffectHandler>();
            }

            isBow = weaponToEquip.GetComponent<Bow>() != null ? true : false;
            isSword = weaponToEquip.GetComponent<Sword>() != null ? true : false;

            OnWeaponChanged?.Invoke();
        }

        public void RotateHand(Rotations rotations)
        {

            childSprite.sortingOrder = 5;
            childSprite.flipY = false;

            if (isSword)
            {
                ChangeSwordRotation(rotations);
            }
            else if (isBow)
            {
                ChanceBowDirection(rotations);
            }
            else
            {
                ChanceStaffDirection(rotations);
            }

        }

        public void ActivateSkill(InputAction.CallbackContext context, PlayerBase playerBase)
        {
            effectHandler.ActivatePassiv(context, playerBase);
        }

        #region Weapon-Rotations
        private void ChangeSwordRotation(Rotations rotations)
        {
            childSprite.sortingOrder = 5;
            if (rotations == Rotations.Down)
            {
                childSprite.flipY = true;
                childSprite.transform.eulerAngles = Vector3.forward * -90f;
                transform.localPosition = startPos + new Vector3(0.1f, 0, 0);
            }
            else if (rotations == Rotations.DownLeft)
            {
                childSprite.flipY = true;
                childSprite.sortingOrder = 1;
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

        private void ChanceBowDirection(Rotations rotations)
        {
            childSprite.sortingOrder = 5;
            if (rotations == Rotations.Down)
            {
                childSprite.flipY = true;
                childSprite.transform.eulerAngles = Vector3.forward * -90f;
                transform.localPosition = startPos + new Vector3(0.1f, 0.1f, 0);
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
                transform.localPosition = startPos + new Vector3(0.2f, 0, 0);
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

        private void ChanceStaffDirection(Rotations rotations)
        {
            childSprite.sortingOrder = 5;
            if (rotations == Rotations.Down)
            {
                childSprite.flipY = true;
                childSprite.transform.eulerAngles = Vector3.forward * -45;
                transform.localPosition = startPos + new Vector3(0.1f, 0, 0);
            }
            else if (rotations == Rotations.DownLeft)
            {
                childSprite.flipY = true;
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * -135;
                transform.localPosition = startPos + new Vector3(0.2f, 0, 0);
            }
            else if (rotations == Rotations.Left)
            {
                childSprite.flipY = true;
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * 220;
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
                childSprite.transform.eulerAngles = Vector3.forward * 30;
                transform.localPosition = startPos + new Vector3(0.8f, 0, 0);
            }
            else if (rotations == Rotations.UpRight)
            {
                childSprite.sortingOrder = 1;
                childSprite.transform.eulerAngles = Vector3.forward * -30;
                transform.localPosition = startPos + new Vector3(0.6f, 0, 0);
            }
            else if (rotations == Rotations.Right)
            {
                childSprite.transform.eulerAngles = Vector3.forward * -45;
                transform.localPosition = startPos + new Vector3(0.3f, 0, 0);
            }
            else if (rotations == Rotations.DownRight)
            {
                childSprite.transform.eulerAngles = Vector3.forward * -20;
                transform.localPosition = startPos + new Vector3(0.1f, 0, 0);
            }
        }
        #endregion
    }
}