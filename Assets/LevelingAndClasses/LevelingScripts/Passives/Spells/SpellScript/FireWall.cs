using System;
using System.Collections.Generic;
using Combat;
using UnityEngine;
using Utils;

public class FireWall : MonoBehaviour
{
    public int baseDamage = 20;
    public int activeTime = 5;

    private List<Collider2D> enemyList = new List<Collider2D>();

    [SerializeField] 
    private float timer = 1;
    [SerializeField]
    private float timerMax = 1;
    
    public DamageType damageType = DamageType.Magical;
    //public GameObject impactEffect;
    
    void Start()
    {
        Invoke("DestroyAfterTime", activeTime ); 
    }
    
    
    /**
     * If Something Enters hitbox it gets dmg
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Here to do in our Case Dmg
        if(!enemyList.Contains(other))
            enemyList.Add(other);
        
        if (other.gameObject.layer == 6)
        {
            other.GetComponent<Enemy>()?.TakeDamage(baseDamage, Util.GetLocalPlayer(), damageType);
        }
        

        //TODO if we want impactEffects we can use this
        //Instantiate(impactEffect, transform.position, transform.rotation);
        
        //Destroys the Object (Projectile)
    }

    /**
     * If Something exit the Hitbox it wont be in this list
     */
    private void OnTriggerExit2D(Collider2D other)
    {
        if(enemyList.Contains(other))
            enemyList.Remove(other);
    }

    /**
     * Every timerMax it does Dmg
     */
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

    void DestroyAfterTime()
    {
        Destroy(gameObject);
    }

    /**
     * Everything in the List gets Dmg
     */
    private void DoDmg()
    {
        foreach (var other in enemyList)
        {
            if (other.gameObject.layer == 6)
            {
                other.GetComponent<Enemy>()?.TakeDamage(baseDamage, Util.GetLocalPlayer(), damageType);
                Debug.Log("Hit something with FireWall");
            }
        }
    }
}