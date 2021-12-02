using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    //public GameObject impactEffect;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyAfterTime", 5 ); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO From Breakys if we have a Enemy we can trigger Dmg on it
        // Enemy enemy = GitInfo.GetComponent<Enemy>();
        // if (enemy != null)
        // {
        //     enemy.TakeDamage(damage);
        // }
        Debug.Log("Hit something with Fireball");

        //TODO if we want impactEffects we can use this
        //Instantiate(impactEffect, transform.position, transform.rotation);
        
        //Destroys the Object (Projectile)
    }

    void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
}
