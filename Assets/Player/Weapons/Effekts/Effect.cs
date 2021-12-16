using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.Effects
{
    public class Effect : ScriptableObject
    {

        [Header("Effect identifiers")] public string effectName;
        public Combat.DamageType elementTyp;
        public EquipableWeapon.WeaponRarity weaponRarity;
        public EffectTyp EffectTyp;
        public string effectDescription;

        [Header("Effectstats")]
        public float activeTime;
        public float cooldown;
        public float baseDamage;

        private float penetration;
        private float bonusStat;

        //The weapon where to cast from
        public virtual void Activate(GameObject player) { }
        public virtual void Deactivate() { }
        public virtual void Passiv() { }
        public virtual void ActivateOnHit() { }
    }
}

