using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerTank : PlayerBase
    {
        private void Update()
        {
            PlayerBaseMovementHandler();
        }

        private void FixedUpdate()
        {
            PlayerBaseStateHandler();
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
        #endregion
    }
}
