using UnityEngine;
using Combat;

namespace EquipableWeapon
{
    public enum WeaponRarity
    {
        Bad = 1,
        Common = 2,
        Uncommon = 3,
        Mystic = 4,
        Legendary = 5,
    }

    public abstract class Weapon : MonoBehaviour
    {
        [Header("Basestats")] public float baseDamage;
        public float baseRange;
        public float baseAttackspeed;
        public float baseAOERange;

        [Header("Bonustats")] public Effekts.Effekt weaponEffekt;
        public WeaponRarity weaponRarity;
        public DamageType damageType;

        private SpriteRenderer spriteRenderer;


        public void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            baseAOERange *= ((float) weaponRarity / 2);
            baseAttackspeed *= ((float) weaponRarity / 2);
            baseDamage *= ((float) weaponRarity / 2);
            baseRange *= ((float) weaponRarity / 2);
            ChangeSpriteColor(weaponRarity);
        }

        private void ChangeSpriteColor(WeaponRarity rarity)
        {
            if (rarity == WeaponRarity.Common)
            {
                spriteRenderer.color = Color.white;
            }
            else if (rarity == WeaponRarity.Bad)
            {
                spriteRenderer.color = new Color(0.93f, 0.56f, 0.4f);
            }
            else if (rarity == WeaponRarity.Uncommon)
            {
                spriteRenderer.color = new Color(0.34f, 0.88f, 0.93f);
            }
            else if (rarity == WeaponRarity.Mystic)
            {
                spriteRenderer.color = new Color(0.92f, 0.92f, 0.35f);
            }
            else if (rarity == WeaponRarity.Legendary)
            {
                spriteRenderer.color = new Color(0.78f, 0.92f, 0.34f);
            }
        }

        public abstract void Attack(CombatStats combatStats);
    }
}