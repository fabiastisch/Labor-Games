using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Effects
{
    public class EffectBonusStats 
    {
        public float penetration { get; set; }
        public float rareStat { get; set; }
        public Effect effect { get; set; }

        public EffectBonusStats(float penetration, float rareStat, Effect effect)
        {
            this.penetration = penetration;
            this.rareStat = rareStat;
            this.effect = effect;
        }

    }

}
