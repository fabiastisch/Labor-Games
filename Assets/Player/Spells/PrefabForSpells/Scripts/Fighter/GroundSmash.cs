using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class GroundSmash : MonoBehaviour
{
    public float baseDamage = 20f;
    private List<Collider2D> enemyList = new List<Collider2D>();

    [SerializeField] private float timer = 1;
    [SerializeField] private float timerMax = 1;

    [SerializeField] private float factor;

    [SerializeField] private float strength;
    
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
        baseDamage = strength * factor;
        if (baseDamage < 70)
        {
            baseDamage = 70;
        }
    }
}
