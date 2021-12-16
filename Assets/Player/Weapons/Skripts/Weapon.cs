using UnityEngine;
using Combat;
using Weapons.Effects;

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
        public float baseAttackcooldown;
        public float baseAOERange;

        [Header("Rarity & DamageType")] public WeaponRarity weaponRarity;
        public DamageType damageType;
        public bool shouldGenerateRarityDMGTyp = true;


        [Header("Effect & EffectStats")] public Effect? effect;
        public float penetration;
        public float bonusStat;
        private EffectBonusStats weaponEffects;

        public bool shouldGenerateEffect = true;
        public EffectHolder effectPool;

        [Header("Debug")] [SerializeField] protected bool drawGizmos = false;

        private SpriteRenderer spriteRenderer;
        private WeaponRadomizer effectGenerator;
        public void Start()
        {
            effectGenerator = new WeaponRadomizer(effectPool);
            if (shouldGenerateRarityDMGTyp)
            {
                (damageType, weaponRarity) = effectGenerator.GetRandomeDmgtypeAndRarity();
            }

            spriteRenderer = GetComponent<SpriteRenderer>();
            baseAOERange *= ((float) weaponRarity / 2);
            baseAttackcooldown /= ((float) weaponRarity / 2);
            baseDamage *= ((float) weaponRarity / 2);
            ChangeSpriteColor(weaponRarity);

            penetration *= ((float) weaponRarity / 2);
            bonusStat *= ((float) weaponRarity / 2);
            GenerateEffect();
        }

        private void GenerateEffect()
        {
            if (!shouldGenerateEffect)return;

            effect = null;
            weaponEffects = effectGenerator.GenerateEffect(weaponRarity, damageType);
            if (weaponEffects == null)
            {
                return;
            }

            if (weaponEffects.penetration != 0) penetration = weaponEffects.penetration;
            if (weaponEffects.rareStat != 0) bonusStat = weaponEffects.rareStat;

            if (weaponEffects.effect != null)
            {
                effect = weaponEffects.effect;
                Debug.Log(effect.name);
            }
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