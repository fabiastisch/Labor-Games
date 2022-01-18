using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class AuraBase : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] public float baseDamage;
    [SerializeField] private float factor = 0;
    [SerializeField] private float scaleValue = 0;

    private List<Collider2D> enemyList = new List<Collider2D>();

    [SerializeField] private float startTime;
    [SerializeField] private float resetTime;

    [SerializeField] public bool isSpell = true;
    
    [SerializeField]
    private ActualStatsThatGetUsed.ActualValues valueFactor = ActualStatsThatGetUsed.ActualValues.actualAbillityPower;
    
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
            enemy.GetComponent<Enemy>()?.TakeDamage(damage, Util.GetLocalPlayer(), damageType, isSpell);
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
                    enemy.GetComponent<Enemy>()?.TakeDamage(damage, Util.GetLocalPlayer(), damageType , isSpell);
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
        scaleValue = ActualStatsThatGetUsed.Instance.ReturnValue( (int)valueFactor);
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
