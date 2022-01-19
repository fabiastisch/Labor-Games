using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Weapons.Effects
{

    [CreateAssetMenu(fileName = "New Effects", menuName = "WeaponEffects/EffectPool")]
    //This class contains all Weapon Effects
    public class EffectHolder : ScriptableObject
    {


        public EffectDebuffHolder fireEffects;
        public EffectDebuffHolder frostEffects;
        public EffectDebuffHolder lightningEffects;
        public EffectDebuffHolder shadowEffects;
        public EffectDebuffHolder poisonEffects;
        public EffectDebuffHolder physicalEffects;
        public EffectDebuffHolder magicalEffects;


        public Dictionary<string, EffectDebuffHolder> GetEffectDictionary()
        {
            Dictionary<string, EffectDebuffHolder> allEfects = new Dictionary<string, EffectDebuffHolder>
            {
                {"fire", fireEffects},
                {"frost", frostEffects},
                {"lightning", lightningEffects},
                {"poison", poisonEffects},
                {"shadow", shadowEffects},
                {"physical", physicalEffects},
                {"magical", magicalEffects},
            };

            return allEfects;
        }

    }

    [Serializable]
    public struct EffectDebuffHolder
    {
        public Effect[] effects;
        public DebuffTypeSO debuff;
    }
}

