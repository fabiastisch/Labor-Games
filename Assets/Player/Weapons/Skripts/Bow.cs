using Combat;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace EquipableWeapon
{
    public class Bow : Weapon
    {
        [Header("Bow-Stats")]
        public GameObject arrow;
        private float timer;
        public float maxSpeed;


        private float currentDamage;
        private float currentSpeed;

        private bool isheldDown = false;

        private SpriteRenderer arrowRenderer;

        void Start()
        {
            base.Start();
            arrowRenderer = arrow.GetComponent<SpriteRenderer>();
            currentDamage = 0;
            currentSpeed = 0;
        }

        private void Update()
        {
            if (!isheldDown) return;
            ButtonHeldDown();
        }

        public override void Attack(InputAction.CallbackContext context, CombatStats combatStats, PlayerBase player)
        {
            //Timer erhöhen
            if (context.performed)
            {
                isheldDown = true;
            }

            if (context.canceled && currentSpeed != 0)
            {
                isheldDown = false;
                //PlayAnimation
                ChangeSpriteColor(arrowRenderer, weaponRarity);
                GameObject newArrow = Instantiate(arrow, gameObject.transform.position, Quaternion.identity);
                ArrowHeandler arrowHeandler = newArrow.GetComponent<ArrowHeandler>();
                arrowHeandler.setArrowStats(currentSpeed, currentDamage, true, damageType, player);
                currentDamage = 0;
                currentSpeed = 0;
            }
        }

        private void ButtonHeldDown()
        {
            timer += Time.deltaTime;
            Debug.Log(currentDamage);
            if (currentDamage >= baseDamage) return;

            if (timer > 0.5)
            {
                currentDamage += baseDamage / 4;
                currentSpeed += maxSpeed / 4;
                timer = 0;
            }
        }
    }
}
