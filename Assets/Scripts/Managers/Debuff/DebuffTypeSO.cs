using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffTypeSO : ScriptableObject
{
    public string nameString;
    public float durationTime;

    public Combat.DebuffTypes debufftype;
    public virtual void MakeDamage(Combat.Character character) { }
    public virtual void DebuffAction() { }
    public virtual void ChangeStats() { }
    public virtual void RemoveDebuff() { }
}
