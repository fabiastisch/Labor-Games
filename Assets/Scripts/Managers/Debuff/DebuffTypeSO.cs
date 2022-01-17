using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffTypeSO : ScriptableObject
{
    public string nameString;
    public float durationTime;
    public bool currentlyApplied = false;
    private Combat.Character character;
    private float durationTimer;

    public virtual void UpdateDebuff(Combat.Character character) {
        timeDebuff();
        this.character = character;
    }

    //After duration time remove debuff. Reset debufftimer on apply.
    public void timeDebuff()
    {
        if (currentlyApplied)
        {
            currentlyApplied = false;
            durationTimer = durationTime;
        }

        durationTimer -= Time.deltaTime;

        if (durationTimer <= 0)
        {
            RemoveThisDebuff(character);
        }
    }
    public virtual void RemoveThisDebuff(Combat.Character character) { }

}
