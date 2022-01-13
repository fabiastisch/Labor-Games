using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class LiveDrainAura : AuraBase
{
    [SerializeField] private float maxHpFactor = 0.02f;
    [SerializeField] private float underMaxHpFactor = 50f;
    

    public override void TimeOption( List<Collider2D> enemyList)
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

    public override void EnterOption(Collider2D other)
    {
        DoDmg(other.gameObject);
    }
    

    private void DoDmg(GameObject other)
    {
        if (other.layer == 6)
        {
            if ((float) other.GetComponent<Enemy>().GetPercentageHpHigh() < underMaxHpFactor)
            {
                float MaxHpDmg = other.GetComponent<Enemy>().GetMaxHealth() * maxHpFactor;

                //todo heal player for this Amount
                other.GetComponent<Enemy>()?.TakeDamage(MaxHpDmg, Util.GetLocalPlayer(), damageType);
            }
        }
    }
}