using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class Stabbing : MonoBehaviour
{
    public DamageType damageType = DamageType.Physical;
    private List<Collider2D> enemyList = new List<Collider2D>();

    [SerializeField] private float damage;
    [SerializeField] public float baseDamage;
    [SerializeField] private float factor = 0;
    [SerializeField] private float scaleValue = 0;
    
    [SerializeField]
    private ActualStatsThatGetUsed.ActualValues valueFactor = ActualStatsThatGetUsed.ActualValues.actualAttack;
    
    [SerializeField] 
    private float timer = 0.35f;
    [SerializeField]
    private float timerMax = 0.35f;

    private void Update()
    {
        //todo add Charisma Referenz
        
        //use time do Subtract things
        timer -= Time.deltaTime;
        //after Time is over do something and restart Timer
        if (timer <= 0f)
        {
            BaseDmgToStrength();
            timer += timerMax;
            Dmg();
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (!enemyList.Contains(other))
        {
            enemyList.Add(other);

            if (other.gameObject.layer == 6)
            {
                other.GetComponent<Enemy>()?.TakeDamage(baseDamage, Util.GetLocalPlayer(), damageType, true);
            }
        }
    }
    
    private void Dmg()
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
                if (other.gameObject.layer == 6)
                {
                    other.GetComponent<Enemy>()?.TakeDamage(baseDamage, Util.GetLocalPlayer(), damageType, true);
                }
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
            }
        }
    }
    

    private void BaseDmgToStrength()
    {
        scaleValue = ActualStatsThatGetUsed.Instance.ReturnValue( (int)valueFactor);
        damage = scaleValue * factor;
        if (damage < baseDamage)
        {
            damage = baseDamage;
        }
    }
}
