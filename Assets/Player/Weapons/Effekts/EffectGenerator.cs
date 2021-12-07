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

        public EffectGenerator(EffectHolder effectHolder)
        {
            this.effectHolder = effectHolder;
        }

        //Map damagetypes to stats and effects
        //Dictionary: 1. DamageType , 2. base Penetration %, 3. base Bonus Stat %, 4. Effects/Skills
        public Dictionary<DamageType, Tuple<float, float, Effect[]>> effectPool;

        public EffectBonusStats GenerateEffect(WeaponRarity rarity, DamageType damageType) {

            FillPool();
            float[] odds = GetOddsByRarity(rarity);
            float percent = UnityEngine.Random.Range(1,100);
            //Roll how many effects
            float numberOfEffects = GetNumberOfEffects(percent, odds);
            //Return null if the weapon has no effect
            if (numberOfEffects == 0) return null;
            return GetChooseEffects(numberOfEffects,damageType,rarity);
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

        private float GetNumberOfEffects(float rolledNumber, float[] odds)
        {
            if (rolledNumber <= odds[2])
            {
                return 3;
            } 
            else if(rolledNumber <= odds[1])
            {
                return 2;
            }
            else if (rolledNumber <= odds[0])  
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        private EffectBonusStats GetChooseEffects(float numberOfEffects, DamageType damageType, WeaponRarity weaponRarity)
        {
            float[] basicEffectsOdds = { 51, 49 };
            float[] RareEffectsOdds = { 75, 25 };
            float percent = UnityEngine.Random.Range(1, 100);

            float baseStat;
            float rareStat;
            Effect[] effects;

            if (effectPool.TryGetValue(damageType, out Tuple<float,float,Effect[]> value))
            {
                baseStat = value.Item1;
                rareStat = value.Item2;
                effects = value.Item3;

                //TODO: Filter WeaponEffects to rarity
                // effects = FilterEffectsByRarity(effects, weaponRarity);
                int rollSpecialEffect = UnityEngine.Random.Range(0, effects.Length-1);

                switch (numberOfEffects)
                {
                    case 1:
                        if (percent >= basicEffectsOdds[0]) return new EffectBonusStats(baseStat, 0f, null);
                        return new EffectBonusStats(1f, 0f, null);
                    case 2:
                        if (percent <= basicEffectsOdds[1]) return new EffectBonusStats(baseStat, rareStat, null);
                        percent = UnityEngine.Random.Range(1, 100);
                        if (percent >= 75) return new EffectBonusStats(baseStat, rareStat, null);
                        return new EffectBonusStats(baseStat, rareStat, null/*effects[rollSpecialEffect]*/);
                    default:
                        return new EffectBonusStats(baseStat, rareStat, null/*effects[rollSpecialEffect]*/);
                }
            }
            return null;
        }

        private Effect[] FilterEffectsByRarity (Effect[] allEffects, WeaponRarity weaponRarity)
        {
            int fromPosition = 0, toPosition;
            switch (weaponRarity)
            {
                case WeaponRarity.Bad:
                    toPosition = 0;
                    break;
                case WeaponRarity.Uncommon:
                    toPosition = 2;
                    break;
                case WeaponRarity.Mystic:
                    toPosition = 3;
                    break;
                case WeaponRarity.Legendary:
                    fromPosition = 3;
                    toPosition = 4;
                    break;
                default:
                    //Common rarity
                    toPosition = 1;
                    break;
            }

            Effect[] sortedEffects = new Effect[toPosition];

            for (int i = fromPosition; i <= toPosition; i++ )
            {
                sortedEffects[i]  = allEffects[i];
            }
            return sortedEffects;
        }

        private void FillPool()
        {
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

