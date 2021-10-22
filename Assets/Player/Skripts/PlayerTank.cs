using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EquipableWeapon;
using Combat;


namespace Player
{
    public class PlayerTank : PlayerBase
    {
        [Header("Weapon")]
        [SerializeField] private Weapon equiptWeapon;

        //
        private CombatStats combatStats = new CombatStats();


        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }
        #region Spellcast
        public override void CastAbillity1()
        {
            Debug.Log("Erruption");
        }

        public override void CastAbillity2()
        {
            Debug.Log("Ignite");
        }

        public override void CastAbillity3()
        {
            Debug.Log("Thunder");
        }

        public override void CastAbillity4()
        {
            Debug.Log("Iceball");
        }

        public override void CastAbillity5()
        {
            Debug.Log("Fireball");
        }

        public override void CastPrimaryAttack()
        {
            equiptWeapon.Attack(combatStats);
        }
        #endregion
    }
}
