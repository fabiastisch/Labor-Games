using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

namespace Effects
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
        public GameObject player;
        private EquipableWeapon.Weapon weapon;
        private Effect effect;
        private float cooldown;
        private float activeTime;

        bool buttonPressed = false;
        bool isWeaponEqquiped = false;

        public EffectState state = EffectState.ready;

        private bool hasWeaponAnEffect = false;
        // Start is called before the first frame update
        void Start()
        {
            weapon = GetComponent<EquipableWeapon.Weapon>();
            if (weapon.effect != null)
            {
                effect = weapon.effect;
                hasWeaponAnEffect = true;
            }
        }

        // Update is called once per frame
        void Update()
        {

            isWeaponEqquiped = weapon.gameObject.layer == 9 ? true : false;
            if (!hasWeaponAnEffect || !isWeaponEqquiped)return;

 
            //If it is an effect which you can activate on buttonpress
            if (effect.EffectTyp == EffectTyp.onActivate)
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
                        return;
                }
            }
        }
        public void ActivatePassiv(InputAction.CallbackContext context)
        {
            if (!context.performed || state != EffectState.ready) return;
            buttonPressed = true;
        }
    }
}
