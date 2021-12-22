using System.Collections.Generic;
using Combat;
using UnityEngine;

public class Aura : MonoBehaviour
{
    public Rigidbody2D rb;
    public int baseDamage = 20;
    public int activeTime = 5;

    private List<Collider2D> enemyList = new List<Collider2D>();

    [SerializeField] 
    private float timer = 1;
    [SerializeField]
    private float timerMax = 1;
    
    public DamageType damageType = DamageType.Magical;
    
    
    void Update()
    {
        
    }
}
