using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class AuraBase : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float baseDamage;
    [SerializeField] private float factor;
    [SerializeField] private float scaleValue;

    private List<Collider2D> enemyList = new List<Collider2D>();

    [SerializeField] private float startTime;
    [SerializeField] private float resetTime;
    
    public DamageType damageType = DamageType.Magical;
    
    
    public virtual void Update()
    {
        BaseDmgFromValueAndFactor();
        startTime -= Time.deltaTime;
        if (startTime <= 0f)
        {
            TimeOption(enemyList);
            startTime += resetTime;
        }
    }
    
    public virtual void DoDmg(GameObject enemy)
    {
        if (enemy.layer == 6)
        {
            enemy.GetComponent<Enemy>()?.TakeDamage(damage, Util.GetLocalPlayer(), damageType);
        }
    }
    
    public virtual void DoDmgToAll()
    {
        if (!enemyList.Any())
        {
            return;
        }

        for (int counter = enemyList.Count - 1; counter >= 0; counter--)
        {
            if (enemyList[counter] != null)
            {
                GameObject enemy = enemyList[counter].gameObject;
                if (enemy.layer == 6)
                {
                    enemy.GetComponent<Enemy>()?.TakeDamage(damage, Util.GetLocalPlayer(), damageType);
                }
            }
        }
    }
    
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (enemyList.Contains(other)) return;
            enemyList.Add(other);
        EnterOption(other);
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (enemyList.Contains(other))
            enemyList.Remove(other);
        ExitOption(other);
    }

    public virtual void TimeOption( List<Collider2D> enemyList)
    {
        DoDmgToAll();
    }
    
    
    public virtual void BaseDmgFromValueAndFactor()
    {
        damage = scaleValue * factor;
        if (damage < baseDamage)
        {
            damage = baseDamage;
        }
    }
    
    public virtual void EnterOption(Collider2D other)
    {
    }
    
    public virtual void ExitOption(Collider2D other)
    {
    }
}
