using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerTank : PlayerBase
    {
        [Header("Weapon")]
        [SerializeField] private GameObject equiptWeapon;


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

        }
        #endregion
    }
}
