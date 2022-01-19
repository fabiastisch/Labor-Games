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

        [Header("Wand-Stats")] public float aoeRange;
        public float aoeDamage;
        public float aoeTime;
        public float magicballSpeed;

        private SpriteRenderer ballRenderer;
        public bool canFireAgain = true;

        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            aoeRange *= ((float)weaponRarity / 2);
            aoeDamage *= ((float)weaponRarity / 2);
            aoeTime *= ((float)weaponRarity / 2);
            ballRenderer = magicball.GetComponent<SpriteRenderer>();
        }

        public override void Attack(InputAction.CallbackContext context, CombatStats combatStats, PlayerBase player)
        {
            if (context.performed)
            {
                if (!canFireAgain) return;
                Attacked();
                Utils.ElementColoring.RecolorSpriteByDamagetyp(ballRenderer, damageType);
                GameObject ball = Instantiate(magicball, transform.position, Quaternion.identity);
                MagicballHandler magicballHandler = ball.GetComponent<MagicballHandler>();
                magicballHandler.SetBallsStats(this, magicballSpeed, baseDamage, aoeDamage, aoeRange, aoeTime, damageType, player);
                canFireAgain = false;
            }
        }
    }
}

