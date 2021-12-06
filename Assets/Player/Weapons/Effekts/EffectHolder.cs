using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Effects{

    [CreateAssetMenu(fileName = "New Effects", menuName="Weapon Effect")]
    //This class contains all Weapon Effects
    public class EffectHolder : ScriptableObject
    {
        public Effect[] fireEffects;
        public Effect[] frostEffects;
        public Effect[] lightningEffects;
        public Effect[] shadowEffects;
        public Effect[] poisonEffects;
        public Effect[] physicalEffects;
        public Effect[] magicalEffects;


        public Dictionary<string, Effect[]> GetEffectDictionary()
        {
            Dictionary<string, Effect[]> allEfects = new Dictionary<string, Effect[]>
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
}

