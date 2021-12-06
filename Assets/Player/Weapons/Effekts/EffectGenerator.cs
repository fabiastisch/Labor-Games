using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EquipableWeapon;
using Combat;
using System;

namespace Effects
{

    public class EffectGenerator
    {
        private Dictionary<string, Effect[]> effects;
        private EffectHolder effectHolder;

        public EffectGenerator(EffectHolder effects)
        {
            effects = effectHolder;
        }

        //Map damagetypes to stats and effects
        //Dictionary: 1. DamageType , 2. base Penetration %, 3. base Bonus Stat %, 4. Effects/Skills
        private Dictionary<DamageType, Tuple<float, float, Effect[]>> effectPool;

        public EffectBonusStats GenerateEffect(WeaponRarity rarity, DamageType damageType) {

            FillPool();
            float[] odds = GetOddsByRarity(rarity);

            /* 1. Roll how many effect
             * 2. Roll whith Effects the weapon should have
             * 3. Add rarity scaling to the stats
             */
            return new EffectBonusStats(0,0,new Effect());
        }

        private float[] GetOddsByRarity(WeaponRarity weaponRarity)
        {
            switch (weaponRarity)
            {
                case WeaponRarity.Bad:
                    return new float[] { 45, 0, 0 };
                case WeaponRarity.Uncommon:
                    return new float[] { 80, 20, 10 };
                case WeaponRarity.Mystic:
                    return new float[] { 90, 30, 20 };
                case WeaponRarity.Legendary:
                    return new float[] { 100, 50, 30 };
                default:
                    //Common rarity
                    return new float[] { 60, 10, 1 };
            }
        }  
        
        private void FillPool()
        {
            effectHolder = new EffectHolder();
            effects = effectHolder.GetEffectDictionary();
            Dictionary<DamageType, Tuple<float, float, Effect[]>> pool = new Dictionary<DamageType, Tuple<float, float, Effect[]>>
            {
                {DamageType.Physical, new Tuple<float, float, Effect[]>(2f,3f, effects["physical"])},
                {DamageType.Magical,new Tuple<float, float, Effect[]>(2f,3f,effects["magical"])},
                {DamageType.Fire,new Tuple<float, float, Effect[]>(2f,3f,effects["fire"])},
                {DamageType.Lightning,new Tuple<float, float, Effect[]>(2f,3f,effects["lightning"])},
                {DamageType.Poison,new Tuple<float, float, Effect[]>(2f,3f,effects["poison"])},
                {DamageType.Frost,new Tuple<float, float, Effect[]>(2f,3f,effects["frost"])},
                {DamageType.Shadow,new Tuple<float, float, Effect[]>(2f,3f,effects["shadow"])}
            };

            effectPool = pool;
        }
    }
}

