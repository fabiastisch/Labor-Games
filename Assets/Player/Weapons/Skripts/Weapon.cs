using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
    public float baseDamage;
    public float baseRange;
    public float baseAttackspeed;
    public float baseAOERange;
 
    public void PickMeUp()
    {

    }

    public void ThrowMeAway()
    {

    }

    public abstract void Attack();
}
