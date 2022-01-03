using Combat;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EquipableWeapon
{
    public class Magicwand : Weapon
    {

        [SerializeField] private GameObject magicball;
        private MagicballHandler magicballHandler;

        [Header("Wand-Stats")] public float aoeRange;
        public float aoeDamage;
        public float magicballSpeed;

        private SpriteRenderer ballRenderer;
        private bool canFireAgain = true;

        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            aoeRange *= ((float)weaponRarity / 2);
            aoeDamage *= ((float)weaponRarity / 2);
            ballRenderer = magicball.GetComponent<SpriteRenderer>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Attack(InputAction.CallbackContext context, CombatStats combatStats, PlayerBase player)
        {
            if (context.performed)
            {
                if (!canFireAgain) return;

                Utils.ElementColoring.RecolorSpriteByDamagetyp(ballRenderer, damageType);

                canFireAgain = false;
            }
        }
    }
}

