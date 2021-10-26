using Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EquipableWeapon
{
    public class Sword : Weapon
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Attack(CombatStats combatStats)
        {
            Debug.Log("Wuush Wuuush");
        }
    }
}

