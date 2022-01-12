using System.Collections.Generic;
using Combat;
using UnityEngine;

public class AuraHpForEachEnemy : AuraBase
{
    private List<Collider2D> enemyList = new List<Collider2D>();
    //private DebuffType debuffType

    [SerializeField] private float maxReduction = 20f;
    [SerializeField] private float reductionPerEnemy = 0.4f;
    [SerializeField] private float hpPerEnemy = 2f;

    public override void TimeOption()
    {
        HigherHpAndReduction();
    }

    private void HigherHpAndReduction()
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