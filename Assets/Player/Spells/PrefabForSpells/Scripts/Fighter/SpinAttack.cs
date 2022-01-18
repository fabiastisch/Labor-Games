using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class SpinAttack : MonoBehaviour
{
    public DamageType damageType = DamageType.Physical;
    private List<Collider2D> enemyList = new List<Collider2D>();

    private float baseDamage = 5;

    [SerializeField] private float factor;

    private float strength;
    
    [SerializeField] 
    private float timer = 0.25f;
    [SerializeField]
    private float timerMax = 0.25f;
    
    private void Update()
    {
        //todo add Charisma Referenz
        
        //use time do Subtract things
        timer -= Time.deltaTime;
        //after Time is over do something and restart Timer
        if (timer <= 0f)
        {
            DmgList();
            timer += timerMax;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enemyList.Contains(other))
        {
            enemyList.Add(other);

            if (other.gameObject.layer == 6)
            {
               // other.gameObject.GetComponent<Enemy>().setAttackBoolFalse();
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
                //other.gameObject.GetComponent<Enemy>().setAttackBoolTrue();
            }
        }
    }
    
    private void DmgList()
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

    private void BaseDmgToStrength()
    {
        baseDamage = strength * factor;
        if (baseDamage < 5)
        {
            baseDamage = 5;
        }
    }
}