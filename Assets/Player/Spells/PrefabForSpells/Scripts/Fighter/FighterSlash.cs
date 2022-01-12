using System;
using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class FighterSlash : MonoBehaviour
{
    public DamageType damageType = DamageType.Physical;
    private List<Collider2D> enemyList = new List<Collider2D>();

    private float baseDamage = 50;

    [SerializeField] private float factor;

    private float strength;
    
    [SerializeField] 
    private float timer = 1f;
    [SerializeField]
    private float timerMax = 1f;

    private void Awake()
    {
        
    }

    private void Update()
    {
        //todo add Charisma Referenz
        
        //use time do Subtract things
        timer -= Time.deltaTime;
        //after Time is over do something and restart Timer
        if (timer <= 0f)
        {
            timer += timerMax;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            other.GetComponent<Enemy>()?.TakeDamage(baseDamage, Util.GetLocalPlayer(), damageType);
        }
    }
    
    
    

    private void BaseDmgToStrength()
    {
        baseDamage = strength * factor;
    }
}