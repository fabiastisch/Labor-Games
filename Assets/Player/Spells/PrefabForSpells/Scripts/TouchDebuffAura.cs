using System.Collections.Generic;
using Combat;
using UnityEngine;

public class TouchDebuffAura : AuraBase
{
    //private DebuffType debuffType
    
    
    public override void TimeOption()
    {
    }

    public override void EnterOption(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            // other.gameObject.GetComponent<Enemy>().giveDebuff(debuffType);
        }
    }

    public override void ExitOption(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            // other.gameObject.GetComponent<Enemy>().removeDebuff(debuffType);
        }
    }
}