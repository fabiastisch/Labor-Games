using UnityEngine;
using Combat;
using Player;
using Weapons.Effects;
using UnityEngine.InputSystem;

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
        [Header("UI")] public Sprite defaultSprite;
        [Header("Basestats")] public float baseDamage;

        [Header("Rarity & DamageType")] public WeaponRarity weaponRarity;
        public DamageType damageType;
        public bool shouldGenerateRarityDMGTyp = true;

        [Header("Effect & EffectStats")] public Effect? effect;
        public DebuffTypeSO baseStat;
        public float bonusStat;
        private EffectBonusStats weaponEffects;

        public bool shouldGenerateEffect = true;
        public EffectHolder effectPool;

        [Header("Debug")] [SerializeField] protected bool drawGizmos = false;

        private SpriteRenderer spriteRenderer;
        private WeaponRadomizer effectGenerator;

        public bool isOnCooldown = false;
        public float currentCooldown = 0f;
        public float maxCooldown = 1f;
        
        public void Start()
        {
            effectGenerator = new WeaponRadomizer(effectPool);
            if (shouldGenerateRarityDMGTyp)
            {
                (damageType, weaponRarity) = effectGenerator.GetRandomeDmgtypeAndRarity();
            }

            spriteRenderer = GetComponent<SpriteRenderer>();
            baseDamage *= ((float) weaponRarity / 2);
            ChangeSpriteColor(spriteRenderer, weaponRarity);

            if(baseStat != null)
            {
                baseStat.durationTime *= ((float)weaponRarity / 2);
                var burneffeckt = baseStat as HpBurning;
                if (burneffeckt != null) burneffeckt.damagePerSecond *= ((float)weaponRarity / 2);
            }

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

            if (weaponEffects.baseStat != null) baseStat = weaponEffects.baseStat;
            if (weaponEffects.rareStat != 0) bonusStat = weaponEffects.rareStat;

            if (weaponEffects.effect != null)
            {
                effect = weaponEffects.effect;
            }

            if (baseStat != null)
            {
                baseStat.durationTime *= ((float)weaponRarity / 2);
                var burneffeckt = baseStat as HpBurning;
                if (burneffeckt != null) burneffeckt.damagePerSecond *= ((float)weaponRarity / 2);
            }

        }

        public void ChangeSpriteColor(SpriteRenderer sprite, WeaponRarity rarity)
        {
            if (rarity == WeaponRarity.Common)
            {
                sprite.color = Color.white;
            }
            else if (rarity == WeaponRarity.Bad)
            {
                sprite.color = new Color(0.93f, 0.56f, 0.4f);
            }
            else if (rarity == WeaponRarity.Uncommon)
            {
                sprite.color = new Color(0.34f, 0.88f, 0.93f);
            }
            else if (rarity == WeaponRarity.Mystic)
            {
                sprite.color = new Color(0.92f, 0.92f, 0.35f);
            }
            else if (rarity == WeaponRarity.Legendary)
            {
                sprite.color = new Color(0.78f, 0.92f, 0.34f);
            }
        }

        public abstract void Attack(InputAction.CallbackContext context, CombatStats combatStats, PlayerBase player);

    }
}