using UnityEngine;
using Combat;
using UnityEngine.InputSystem;
using Utils;


namespace Player
{
    public class PlayerTank : PlayerBase
    {
        private CombatStats combatStats = new CombatStats();

        protected override void Start()
        {
            base.Start();
            Combat.Character.OnEntityDies += character => { Debug.Log("EntityDies: killer was: " + character); };
            OnPlayerTakeDamage += (enemy, type, arg3, arg4) => { Debug.Log("PlayerTakes Damage"); };
            OnPlayerMoves += b => { /*Debug.Log(b ? "Player Moves" : "Player is not moving");*/ };
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
            //SpellSlot -> hast du nen Spell ? Return true; false
            Util.GetLocalPlayer().InvokeOnPlayerCastSpell();
            Debug.Log("Erruption");
        }

        public override void CastAbillity2()
        {
            Util.GetLocalPlayer().InvokeOnPlayerCastSpell();
            Debug.Log("Ignite");
        }

        public override void CastAbillity3()
        {
            Util.GetLocalPlayer().InvokeOnPlayerCastSpell();
            Debug.Log("Thunder");
        }

        public override void CastAbillity4()
        {
            Util.GetLocalPlayer().InvokeOnPlayerCastSpell();
            Debug.Log("Iceball");
        }

        public override void CastAbillity5()
        {
            Util.GetLocalPlayer().InvokeOnPlayerCastSpell();
            Debug.Log("Fireball");
        }

        public override void CastPrimaryAttack(InputAction.CallbackContext context)
        {
            hand.currentWeapon.Attack(context,combatStats, this);
        }

        public void ActivateWeaponSkill(InputAction.CallbackContext context)
        {
            hand.ActivateSkill(context, this);
        }
        #endregion
    }
}