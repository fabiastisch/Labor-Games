using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Effects{

    [CreateAssetMenu(fileName = "New Effects", menuName = "Weapon Effect")]
    //This class contains all Weapon Effects
    public class EffectHolder : ScriptableObject
    {
        public Effect[] fireEffects = new Effect[5];
        public Effect[] frostEffects = new Effect[5];
        public Effect[] lightningEffects = new Effect[5];
        public Effect[] shadowEffects = new Effect[5];
        public Effect[] poisonEffects = new Effect[5];
        public Effect[] physicalEffects = new Effect[5];
        public Effect[] magicalEffects = new Effect[5];


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

