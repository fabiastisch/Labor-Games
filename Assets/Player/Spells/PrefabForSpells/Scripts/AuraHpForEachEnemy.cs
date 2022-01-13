using System.Collections.Generic;
using Combat;
using UnityEngine;

public class AuraHpForEachEnemy : AuraBase
{
    //private DebuffType debuffType

    [SerializeField] private float maxReduction = 20f;
    [SerializeField] private float reductionPerEnemy = 0.4f;
    [SerializeField] private float hpPerEnemy = 2f;

    public override void TimeOption( List<Collider2D> enemyList)
    {
        HigherHpAndReduction(enemyList);
    }

    private void HigherHpAndReduction(List<Collider2D> enemyList)
    {
        float hpBuff = hpPerEnemy * enemyList.Count;
        float reductionBuff = reductionPerEnemy * enemyList.Count;

        if (reductionBuff > maxReduction)
        {
            reductionBuff = maxReduction;
        }
        
        //player.setAuraHP(hpBuff)
        //player.setAuraReduction(reductionBuff)
            
    }
    
    
}