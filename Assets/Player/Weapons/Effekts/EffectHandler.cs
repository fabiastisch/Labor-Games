using Player;
using UnityEngine.InputSystem;
using UnityEngine;

namespace Weapons.Effects
{

    public enum EffectTyp
    {
        onHit,
        onActivate,
        passiv,
    }
    public enum EffectState
    {
        ready,
        active,
        onRefreshing
    };

    public class EffectHandler : MonoBehaviour
    {
        private EquipableWeapon.Weapon weapon;
        private Effect effect;
        private float cooldown;
        private float activeTime;

        bool buttonPressed = false;
        bool isWeaponEqquiped = false;

        public EffectState state = EffectState.ready;
        private bool hasWeaponAnEffect = false;
        private PlayerBase player;
        
        void Start()
        {
            weapon = GetComponent<EquipableWeapon.Weapon>();
        }

        void Update()
        {
            if (weapon.effect != null)
            {
                effect = weapon.effect;
                hasWeaponAnEffect = true;
            }

            isWeaponEqquiped = weapon.gameObject.layer == 9 ? true : false;
            if (!hasWeaponAnEffect || !isWeaponEqquiped) return;

            //If effect activates on buttonpress
            if (effect.EffectTyp == EffectTyp.onActivate)
            {
                ActivateSkill();
                return;
            }

            //If effect activates on basicattacks
            if (effect.EffectTyp == EffectTyp.onHit)
            {
                OnHitEffect();
                return;
            }

            //If effect activates in a spezific time
            if (effect.EffectTyp == EffectTyp.passiv)
            {
                PassivEffect();
                return;
            }
        }

        #region Skillmethods
        private void OnHitEffect() { }

        private void PassivEffect() { }

        private void ActivateSkill()
        {
            switch (state)
            {
                case EffectState.ready:

                    if (buttonPressed)
                    {
                        effect.Activate(player);
                        buttonPressed = false;
                        state = EffectState.active;
                        activeTime = effect.activeTime;
                    }
                    break;

                case EffectState.active:

                    if (activeTime > 0)
                    {
                        effect.Activate(player);
                        activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        state = EffectState.onRefreshing;
                        cooldown = effect.cooldown;
                    }
                    break;

                case EffectState.onRefreshing:
                    if (cooldown > 0)
                    {
                        effect.Deactivate();
                        cooldown -= Time.deltaTime;
                    }
                    else
                    {
                        state = EffectState.ready;
                    }
                    break;
            }
        }
        #endregion
        public void ActivatePassiv(InputAction.CallbackContext context, PlayerBase playerBase)
        {
            this.player = playerBase;
            if (!context.performed || state != EffectState.ready || weapon.effect == null) return;
            buttonPressed = true;
        }
    }
}
