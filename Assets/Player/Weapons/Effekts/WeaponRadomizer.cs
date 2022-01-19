using System;
using System.Collections.Generic;
using System.Linq;
using Combat;
using EquipableWeapon;
using UnityEngine;
using Utils;

namespace Weapons.Effects
{
    public class WeaponRadomizer
    {
        private Dictionary<string, EffectDebuffHolder> effects;
        private EffectHolder effectHolder;

        private DamageType[] dmgTypePool = 
            {
                DamageType.Fire,
                DamageType.Frost,
                DamageType.Lightning,
                DamageType.Magical,
                DamageType.Physical,
                DamageType.Poison, 
                DamageType.Shadow 
            };

        private WeaponRarity[] weaponRaritiesPool =
            {
                WeaponRarity.Legendary,
                WeaponRarity.Mystic,
                WeaponRarity.Uncommon,
                WeaponRarity.Bad,
                WeaponRarity.Common,
            };

        public WeaponRadomizer(EffectHolder effectHolder)
        {
            this.effectHolder = effectHolder;
        }

        //Map damagetypes to stats and effects
        //Dictionary: 1. DamageType , 2. base Penetration %, 3. base Bonus Stat %, 4. Effects/Skills
        public Dictionary<DamageType, Tuple<DebuffTypeSO, float, Effect[]>> effectPool;

        public EffectBonusStats GenerateEffect(WeaponRarity rarity, DamageType damageType)
        {
            FillPool();
            float[] odds = GetOddsByRarity(rarity);
            //Roll how many effects
            int numberOfEffects = GetNumberOfEffects(odds);
            //Return null if the weapon has no effect
            if (numberOfEffects == 0) return null;
            return GetChoosenEffects(numberOfEffects, damageType, rarity);
        }

        public (DamageType,WeaponRarity) GetRandomeDmgtypeAndRarity()
        {
            int randomNumber = Util.GetRandomInt(0, dmgTypePool.Length - 1);
            DamageType dmgTyp = dmgTypePool[randomNumber];

            float[] weaponRarityChance = { 0.02f, 0.08f, 0.20f, 0.25f, 0.45f };

            int positionInArray = 4;
            for (int i = 0; i < weaponRarityChance.Length; i++)
            {
                if (Util.GetChanceBool(weaponRarityChance[i]))
                {
                    positionInArray = i;
                    break;
                }
            }

            WeaponRarity rarityTyp = weaponRaritiesPool[positionInArray];
            return (dmgTyp, rarityTyp);
        }

        private float[] GetOddsByRarity(WeaponRarity weaponRarity)
        {
            switch (weaponRarity)
            {
                case WeaponRarity.Bad:
                    return new float[] { 0.45f, 0, 0 };
                case WeaponRarity.Uncommon:
                    return new float[] { 0.80f, 0.20f, 0.10f };
                case WeaponRarity.Mystic:
                    return new float[] { 0.90f, 0.30f, 0.20f };
                case WeaponRarity.Legendary:
                    return new float[] { 1f, 0.50f, 0.30f };
                default:
                    //Common rarity
                    return new float[] { 0.60f, 0.10f, 0.01f };
            }
        }

        private int GetNumberOfEffects(float[] odds)
        {
            for (var i = odds.Length - 1; i >= 0; i--)
            {
                if (Util.GetChanceBool(odds[i]))
                {
                    return i + 1;
                }
            }

            return 0;
        }

        private EffectBonusStats GetChoosenEffects(int numberOfEffects, DamageType damageType, WeaponRarity weaponRarity)
        {
            // Odds for Special Effects with 1 and 2 Effects
            float[] specialEffectOdds = { 0.25f, 0.75f };
            // Odds for Rare Effects with 1 and 2 Effects
            float[] rareEffectsOdds = { 0.5f, 0.5f };

            Effect[] effects;

            if (effectPool.TryGetValue(damageType, out Tuple<DebuffTypeSO, float, Effect[]> value))
            {
                DebuffTypeSO baseStat = value.Item1;
                float rareStat = value.Item2;
                effects = value.Item3;

                effects = FilterEffectsByRarity(effects, weaponRarity);
                int specialEffectIndex = Util.GetRandomInt(effects.Length - 1);

                switch (numberOfEffects)
                {
                    case 1:
                        if (Util.GetChanceBool(rareEffectsOdds[0]))
                        {
                            return new EffectBonusStats(null, rareStat, null);
                        }

                        return new EffectBonusStats(baseStat, 0f, null);
                    case 2:
                        if (Util.GetChanceBool(rareEffectsOdds[0]))
                        {
                            if (Util.GetChanceBool(rareEffectsOdds[1]))
                            {
                                return new EffectBonusStats(null, rareStat, effects[specialEffectIndex]); ;
                            }
                        }
                        return new EffectBonusStats(baseStat, rareStat, null);

                    case 3:
                        return new EffectBonusStats(baseStat, rareStat, effects[specialEffectIndex]);

                    default:
                        return new EffectBonusStats(baseStat, rareStat, effects[specialEffectIndex]);
                }
            }

            return null;
        }

        private Effect[] FilterEffectsByRarity(Effect[] allEffects, WeaponRarity weaponRarity)
        {
            return allEffects.ToList().FindAll(effect => effect.weaponRarity <= weaponRarity).ToArray();
        }

        private void FillPool()
        {
            effects = effectHolder.GetEffectDictionary();
            Dictionary<DamageType, Tuple<DebuffTypeSO, float, Effect[]>> pool = new Dictionary<DamageType, Tuple<DebuffTypeSO, float, Effect[]>>
            {
                { DamageType.Physical, new Tuple<DebuffTypeSO, float, Effect[]>(effects["physical"].debuff, 3f, effects["physical"].effects) },
                { DamageType.Magical, new Tuple<DebuffTypeSO, float, Effect[]>(effects["magical"].debuff, 3f, effects["magical"].effects) },
                { DamageType.Fire, new Tuple<DebuffTypeSO, float, Effect[]>(effects["fire"].debuff, 3f, effects["fire"].effects) },
                { DamageType.Lightning, new Tuple<DebuffTypeSO, float, Effect[]>(effects["lightning"].debuff, 3f, effects["lightning"].effects) },
                { DamageType.Poison, new Tuple<DebuffTypeSO, float, Effect[]>(effects["poison"].debuff, 3f, effects["poison"].effects) },
                { DamageType.Frost, new Tuple<DebuffTypeSO, float, Effect[]>(effects["frost"].debuff, 3f, effects["frost"].effects) },
                { DamageType.Shadow, new Tuple<DebuffTypeSO, float, Effect[]>(effects["shadow"].debuff, 3f, effects["shadow"].effects) }
            };

            effectPool = pool;
        }
    }
}