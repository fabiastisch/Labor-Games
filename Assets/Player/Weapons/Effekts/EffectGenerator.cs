using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EquipableWeapon;
using Combat;
using System;

namespace Effects
{

    public class EffectGenerator : ScriptableObject
    {
        // Map damagetypes to stats and effects
        public Dictionary<DamageType, Tuple<float, float>> effectPool = new Dictionary<DamageType, Tuple<float, float /*,Effect[]*/>>
        {
            {DamageType.Physical, new Tuple<float, float>(2f,3f)},
            {DamageType.Magical,new Tuple<float, float>(2f,3f)},
            {DamageType.Fire,new Tuple<float, float>(2f,3f)},
            {DamageType.Lightning,new Tuple<float, float>(2f,3f)},
            {DamageType.Poison,new Tuple<float, float>(2f,3f)},
            {DamageType.Frost,new Tuple<float, float>(2f,3f)},
            {DamageType.Shadow,new Tuple<float, float>(2f,3f)}
        };


        public EffectBonusStats GenerateEffect(WeaponRarity rarity, DamageType damageType) {

            float[] odds = GetOddsByRarity(rarity);

            return null;
        }

        private float[] GetOddsByRarity(WeaponRarity weaponRarity)
        {
            switch (weaponRarity)
            {
                case WeaponRarity.Bad:
                    return new float[] { 45, 0, 0 };
                case WeaponRarity.Common:
                    return new float[] { 60, 10, 1 };
                case WeaponRarity.Uncommon:
                    return new float[] { 80, 20, 10 };
                case WeaponRarity.Mystic:
                    return new float[] { 90, 30, 20 };
                case WeaponRarity.Legendary:
                    return new float[] { 100, 50, 30 };
                default:
                    return new float[] {0,0,0};
            }
        }  
    }
}

