using UnityEngine;
using Combat;
using UnityEngine.InputSystem;


namespace Player
{
    public class PlayerTank : PlayerBase
    {

        //
        private CombatStats combatStats = new CombatStats();


        protected override void Start()
        {
            base.Start();
            Combat.Character.OnEntityDies += character => { Debug.Log("EntityDies: killer was: " + character); };
            OnPlayerTakeDamage += (enemy, type, arg3, arg4) => { Debug.Log("PlayerTakes Damage"); };
            OnPlayerMoves += b => { Debug.Log(b ? "Player Moves" : "Player is not moving"); };
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
            base.hand.currentWeapon.Attack(combatStats, this);
        }

        public void ActivateWeaponSkill(InputAction.CallbackContext context)
        {
            base.hand.ActivateSkill(context, this);
        }
        #endregion
    }
}