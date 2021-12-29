using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
        public Spell spell;
        private PassiveSlot.PassiveState state = PassiveSlot.PassiveState.ready;
        
        private float activeMaxTime;
        private float activeTimer;

        private float cooldownTimer;
        private float cooldownMaxTime;

        private bool spellIsNotNull = false;
        
        public KeyCode key;
        
        
        private void Start()
        {
            spellIsNotNull = spell != null;
        }

        void Update()
        {
            if (spellIsNotNull)
            {
                if (Input.GetKeyDown(key))
                {

                    switch (state)
                    {
                        case PassiveSlot.PassiveState.ready:
                            switch (spell.spellType)
                            {
                                case Spell.SpellType.Aoe:
                                    spell.Activation(gameObject);
                                    state = PassiveSlot.PassiveState.active;
                                    break;

                                case Spell.SpellType.Aura:
                                    spell.Activation(gameObject);
                                    state = PassiveSlot.PassiveState.active;
                                    break;

                                case Spell.SpellType.Projectile:
                                    //Destroys usually itself
                                    spell.Activation(gameObject);
                                    state = PassiveSlot.PassiveState.cooldown;
                                    break;

                                case Spell.SpellType.OnEnemy:
                                    spell.Activation(gameObject);
                                    state = PassiveSlot.PassiveState.active;
                                    break;
                            }

                            break;

                        case PassiveSlot.PassiveState.active:
                            //Active Time
                            activeTimer -= Time.deltaTime;
                            //after Time is over do something and restart Timer
                            if (activeTimer <= 0f)
                            {
                                spell.BeginCooldown(gameObject);
                                activeTimer = activeMaxTime;
                                state = PassiveSlot.PassiveState.cooldown;
                            }

                            break;

                        case PassiveSlot.PassiveState.cooldown:
                            //Cooldown
                            //use time do Subtract things
                            cooldownTimer -= Time.deltaTime;
                            //after Time is over do something and restart Timer
                            if (cooldownTimer <= 0f)
                            {
                                state = PassiveSlot.PassiveState.ready;
                                cooldownTimer = cooldownMaxTime;
                            }

                            break;


                    }
                }
            }
        }

        public void SetCooldown(float amount)
        {
            cooldownTimer = amount;
        }

        /**
        * Percentage between 0 and 1
        */
        public void RemovePrecentageFromTimer(float percentageAmount)
        {
            cooldownTimer -= cooldownTimer * percentageAmount;
        }
    
        /**
        * Percentage between 0 and 1
        */
        public void AddPrecentageToTimer(float percentageAmount)
        {
            cooldownTimer += cooldownTimer * percentageAmount;
        }

        public void CooldownReset()
        {
            cooldownTimer = cooldownMaxTime;
        }
        
        public void SetActive(float amount)
        {
            activeTimer = amount;
        }

        /**
        * Percentage between 0 and 1
        */
        public void RemoveFromActivePercentage(float percentageAmount)
        {
            activeTimer -= activeTimer * percentageAmount;
        }
    
        /**
        * Percentage between 0 and 1
        */
        public void AddToActivePercentage(float percentageAmount)
        {
            activeTimer += activeTimer * percentageAmount;
        }

        public void ActiveReset()
        {
            activeTimer = activeTimer;
        }

        public void AddActiveTime(float amount)
        {
            activeTimer += amount;
        }

        public void AddSpell(Spell spellObject)
        {
            spell = spellObject;
            spellIsNotNull = true;
            activeTimer = spell.activeTimeMax;
            activeMaxTime = spell.activeTimeMax;
            cooldownTimer = spell.cooldownMax;
            cooldownMaxTime = spell.cooldownMax;
            state = PassiveSlot.PassiveState.ready;
            
        }
        
        public void RemoveSpell()
        {
            spell = null;
            spellIsNotNull = false;
            activeTimer = 0;
            activeMaxTime = 0;
            cooldownTimer = 0;
            cooldownMaxTime = 0;

            state = PassiveSlot.PassiveState.ready;
        }



}
