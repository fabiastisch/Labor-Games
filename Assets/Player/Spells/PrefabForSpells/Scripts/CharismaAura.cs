using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class CharismaAura : AuraBase
{
    public override void EnterOption(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            // other.gameObject.GetComponent<Enemy>().setAttackBoolFalse();
        }
    }

    public override void ExitOption(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            // other.gameObject.GetComponent<Enemy>().setAttackBoolFalse();
        }
    }
}