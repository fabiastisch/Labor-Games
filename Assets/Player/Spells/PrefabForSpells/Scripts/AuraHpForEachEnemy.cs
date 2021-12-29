using System.Collections.Generic;
using Combat;
using UnityEngine;

public class AuraHpForEachEnemy : MonoBehaviour
{
    public DamageType damageType = DamageType.Magical;
    private List<Collider2D> enemyList = new List<Collider2D>();
    //private DebuffType debuffType

    [SerializeField] private float maxReduction = 20f;
    [SerializeField] private float reductionPerEnemy = 0.4f;
    [SerializeField] private float hpPerEnemy = 2f;
    
    [SerializeField] 
    private float timer = 1;
    [SerializeField]
    private float timerMax = 1;
    
    private void Update()
    {
        //use time do Subtract things
        timer -= Time.deltaTime;
        //after Time is over do something and restart Timer
        if (timer <= 0f)
        {
            HigherHpAndReduction();
            timer += timerMax;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            if (!enemyList.Contains(other))
            {
                enemyList.Add(other);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            if (enemyList.Contains(other))
                enemyList.Remove(other);
        }
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