using System.Collections;
using System.Collections.Generic;
using Player;
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

        //The weapon where to cast from
        public virtual void Activate(PlayerBase player) { }
        public virtual void Deactivate() { }
        public virtual void Passiv() { }
        public virtual void ActivateOnHit() { }
    }
}

