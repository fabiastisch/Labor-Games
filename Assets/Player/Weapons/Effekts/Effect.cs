using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class Effect : ScriptableObject
    {
        public string effectName;
        public float activeTime;
        public float cooldown;
        public Combat.DamageType elementTyp;
        public string effectDescription;
        public EquipableWeapon.WeaponRarity weaponRarity;
        public EffectTyp EffectTyp;
        public float baseDamage;

        private float penetration;
        private float bonusStat;

        //The weapon where to cast from
        public virtual void Activate(GameObject weapon) { }
        public virtual void Deactivate() { }

        public virtual void Passiv() { }

        public virtual void ActivateOnHit() { }
    }
}

