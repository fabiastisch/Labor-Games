using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class SuperManAura : AuraBase
{

    [SerializeField] private float maxHpFactor = 0.05f;
    
    public override void TimeOption( List<Collider2D> enemyList)
    {
        DmgAll(enemyList);
    }

    public override void EnterOption(Collider2D other)
    {
       DoDmg(other.gameObject);
    }

    private void DmgAll(List<Collider2D> enemyList)
    {
        if (!enemyList.Any())
        {
            return;
        }

        for (int counter = enemyList.Count - 1; counter >= 0; counter--)
        {
            if (enemyList[counter] != null)
            {
                GameObject other = enemyList[counter].gameObject;
                DoDmg(other);
            }
        }
    }

    public override void DoDmg(GameObject other)
    {
        if (other.layer == 6)
        {
            float MaxHpDmg = other.GetComponent<Enemy>().GetMaxHealth() * maxHpFactor;

            other.GetComponent<Enemy>()?.TakeDamage(MaxHpDmg, Util.GetLocalPlayer(), damageType);
        }
    }
}