using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerDMGDealer : PlayerBase
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
            throw new System.NotImplementedException();
        }

        public override void CastAbillity2()
        {
            throw new System.NotImplementedException();
        }

        public override void CastAbillity3()
        {
            throw new System.NotImplementedException();
        }

        public override void CastAbillity4()
        {
            throw new System.NotImplementedException();
        }

        public override void CastAbillity5()
        {
            throw new System.NotImplementedException();
        }

        public override void CastPrimaryAttack(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
