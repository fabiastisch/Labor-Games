using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class GroundSmash : MonoBehaviour
{
    private List<Collider2D> enemyList = new List<Collider2D>();

    [SerializeField] private float timer = 1;
    [SerializeField] private float timerMax = 1;

    [SerializeField] private float damage;
    [SerializeField] public float baseDamage;
    [SerializeField] private float factor = 0;
    [SerializeField] private float scaleValue = 0;
    
    [SerializeField]
    private ActualStatsThatGetUsed.ActualValues valueFactor = ActualStatsThatGetUsed.ActualValues.actualAttack;
    
    public DamageType damageType = DamageType.Physical;
    //public GameObject impactEffect;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fire hitted");
        //Here to do in our Case Dmg
        if (!enemyList.Contains(other))
        {
            enemyList.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemyList.Contains(other))
            enemyList.Remove(other);
    }

    private void Update()
    {
        //use time do Subtract things
        timer -= Time.deltaTime;
        //after Time is over do something and restart Timer
        if (timer <= 0f)
        {
            BaseDmgToStrength();
            DoDmg();
            timer += timerMax;
        }

    }

    private void DoDmg()
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
                    enemy.GetComponent<Enemy>()?.TakeDamage(baseDamage, Util.GetLocalPlayer(), damageType, true);
                }
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
