using System.Collections.Generic;
using Combat;
using UnityEngine;

public class RunAwayAura : MonoBehaviour
{
    public DamageType damageType = DamageType.Magical;
    private List<Collider2D> enemyList = new List<Collider2D>();
    //private DebuffType debuffType
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enemyList.Contains(other))
        {
            enemyList.Add(other);

            if (other.gameObject.layer == 6)
            {
                // other.gameObject.GetComponent<Enemy>().giveDebuff(debuffType);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemyList.Contains(other))
        {
            enemyList.Remove(other);
            if (other.gameObject.layer == 6)
            {
                // other.gameObject.GetComponent<Enemy>().removeDebuff(debuffType);
            }
        }
    }
    
}