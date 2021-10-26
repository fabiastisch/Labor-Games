using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PassiveSlot : MonoBehaviour
{
    public Passive passive;
    private float cooldownTime;
    private float activeTime;
    private bool alltheTimeActive;
    private float repeatingSeconds;
    private float firstActivationForRepeat;
    private bool invokerStarted = false;

    private PassiveState state = PassiveState.ready;
    public KeyCode key;
    
   public enum PassiveState
    {
        ready,
        active,
        cooldown,
        repeatingEffect,
    }

    private void Start()
    {
        state = passive.passiveState;
        activeTime = passive.activeTime;
        alltheTimeActive = passive.allTheTimeActive;
        cooldownTime = passive.cooldown;
        repeatingSeconds = passive.repeatingSeconds;
        firstActivationForRepeat = passive.firstActivationForRepeat;
        if (state == PassiveState.repeatingEffect)
        {
            InvokeRepeating(nameof(Repeater), firstActivationForRepeat, repeatingSeconds);
            invokerStarted = true;
            // CancelInvoke(nameof(Repeater));
        }
    }

    void Update()
    {
        switch (state)
        {
            case PassiveState.ready:
                if (Input.GetKeyDown(key))
                {
                    passive.Activation(gameObject);
                    state = PassiveState.active;
                    activeTime = passive.activeTime;
                }
                else if (alltheTimeActive)
                {
                    passive.Activation(gameObject);
                    state = PassiveState.active;
                }
                break;
            case PassiveState.active:
                if (alltheTimeActive)
                {
                    //will stay here its all the time active
                }
                else
                { 
                    Invoke(nameof(SetStateCoodown), activeTime);
                }
                
                // else if (activeTime > 0)
                // {
                //     activeTime -= Time.deltaTime;
                // }
                // else
                // {
                //     passive.BeginCooldown(gameObject);
                //     state = PassiveState.cooldown;
                //     cooldownTime = passive.cooldown;
                // }
                break;
            case PassiveState.cooldown:
                Invoke(nameof(SetStateReady), cooldownTime);
                /*if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = PassiveState.ready;
                }*/
                break;
            case PassiveState.repeatingEffect:
                break;
                
        }
    }

    private void SetStateReady()
    {
        state = PassiveState.ready;
    }

    private void SetStateCoodown()
    {
        
        passive.BeginCooldown(gameObject);
        state = PassiveState.cooldown;
        cooldownTime = passive.cooldown;
    }

    private void Repeater()
    {
        passive.Activation(gameObject);
    }
}
