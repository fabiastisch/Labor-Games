using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Weapons.Effects
{
    //This class is used to give alle available effects with one return to the weapon class by the EffectGenerator
    public class EffectBonusStats {
        public DebuffTypeSO baseStat { get; set; }
        public float rareStat { get; set; }
        public Effect effect { get; set; }

        public EffectBonusStats(DebuffTypeSO baseStat, float rareStat, Effect effect) {
            this.baseStat = baseStat;
            this.rareStat = rareStat;
            this.effect = effect;
        }

        public EffectBonusStats() {
        }
    }
}