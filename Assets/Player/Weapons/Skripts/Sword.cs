using Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EquipableWeapon
{
    public class Sword : Weapon
    {
        private Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Attack(CombatStats combatStats)
        {
            animator.Play("SwingSwordAnimation");
            Debug.Log("Wuush Wuuush");
        }
    }
}

