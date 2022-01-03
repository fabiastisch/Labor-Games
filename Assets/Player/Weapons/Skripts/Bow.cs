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
        [SerializeField] private GameObject arrow;
        public float maxSpeed;

        public Sprite minLoadSprite;
        public Sprite midLoadSprite;
        public Sprite maxLoadeSprite;
        private Sprite defaultSprite;

        private float timer;
        private float currentDamage;
        private float currentSpeed;
        private bool isheldDown = false;

        private SpriteRenderer bowRenderer;
        private SpriteRenderer arrowRenderer;

        void Start()
        {
            base.Start();

            arrowRenderer = arrow.GetComponent<SpriteRenderer>();
            bowRenderer = GetComponent<SpriteRenderer>();
            defaultSprite = bowRenderer.sprite;

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

                ChangeSpriteColor(arrowRenderer, weaponRarity);
                GameObject newArrow = Instantiate(arrow, gameObject.transform.position, Quaternion.identity);
                ArrowHeandler arrowHeandler = newArrow.GetComponent<ArrowHeandler>();
                arrowHeandler.setArrowStats(currentSpeed, currentDamage, true, damageType, player);

                currentDamage = 0;
                currentSpeed = 0;

                bowRenderer.sprite = defaultSprite;
            }
        }

        private void ButtonHeldDown()
        {
            timer += Time.deltaTime;
            if (currentDamage >= baseDamage)
            {
                bowRenderer.sprite = maxLoadeSprite;
                return;
            }

            if (timer > 0.5)
            {
                currentDamage += baseDamage / 4;
                currentSpeed += maxSpeed / 4;
                timer = 0;
            }
            if(currentDamage >= baseDamage / 2)
            {
                bowRenderer.sprite = midLoadSprite;
            }
            else
            {
                bowRenderer.sprite = minLoadSprite;
            }
            
        }
    }
}
