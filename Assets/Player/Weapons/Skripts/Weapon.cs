using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;

namespace EquipableWeapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [Header("Basestats")]
        public float baseDamage;
        public float baseRange;
        public float baseAttackspeed;
        public float baseAOERange;

        public void PickMeUp()
        {

        }

        public void ThrowMeAway()
        {

        }

        public abstract void Attack(CombatStats combatStats);
    }

}

