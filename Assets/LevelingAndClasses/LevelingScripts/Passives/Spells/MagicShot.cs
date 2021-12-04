using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Abillitys/Fireball")]
public class MagicShot : Passive

{
    // public float flyDuration;
    // public float speed;
    [SerializeField] private GameObject magicProjectile;
    
    //I cant Drag a Scene Object into here so i need to initialize it in the script
    private Transform firePoint = null;
    
    // [SerializeField] private Animation CastAnimation;
    

    public override void Activation(GameObject parent)
    {
        
        //Todo find a way to define a other transform without get child
        Transform findChildName = parent.transform.Find("Hand").Find("FirePoint");
        if (findChildName != null)
        {
            firePoint = findChildName;
        }
        else 
            firePoint = null;
        FireBall();
    }

    public override void BeginCooldown(GameObject parent)
    {
        base.BeginCooldown(parent);
    }

    void FireBall()
    {
        Debug.Log("Cast Fireball");
        Instantiate(magicProjectile, firePoint.position, firePoint.rotation);
    }
}
