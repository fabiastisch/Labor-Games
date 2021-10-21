using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSlot : MonoBehaviour
{
    public Passive passive;
    private float cooldownTime;
    private float activeTime;

    enum PassiveState
    {
        ready,
        active,
        cooldown
    }

    private PassiveState state = PassiveState.ready;
    public KeyCode key;
    

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
                break;
            case PassiveState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    passive.BeginCooldown(gameObject);
                    state = PassiveState.cooldown;
                    cooldownTime = passive.cooldown;
                }
                break;
            case PassiveState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = PassiveState.ready;
                }
                break;
        }
    }
}
