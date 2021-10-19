using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerTank : PlayerBase
    {
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
            Debug.Log("Heyya");
        }

        public override void CastAbillity2()
        {
            Debug.Log("Heyya");
        }

        public override void CastAbillity3()
        {
            Debug.Log("Heyya");
        }

        public override void CastAbillity4()
        {
            Debug.Log("Heyya");
        }

        public override void CastAbillity5()
        {
            Debug.Log("Heyya");
        }

        public override void CastPrimaryAttack()
        {
            Debug.Log("Heyya");
        }
        #endregion
    }
}
