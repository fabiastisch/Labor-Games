using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Weapons.Effects
{
    //This class is used to give alle available effects with one return to the weapon class by the EffectGenerator
    public class EffectBonusStats {
        public float penetration { get; set; }
        public float rareStat { get; set; }
        public Effect effect { get; set; }

        public EffectBonusStats(float penetration, float rareStat, Effect effect) {
            this.penetration = penetration;
            this.rareStat = rareStat;
            this.effect = effect;
        }

        public EffectBonusStats() {
        }
    }
}