using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Effekts
{
    public abstract class Effekt : ScriptableObject
    {
        public Combat.DamageType elementTyp;
        public EquipableWeapon.WeaponRarity weaponRarity;
        public abstract void DoEffekt();
    }
}

