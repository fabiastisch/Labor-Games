using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "ScriptableObject/Spell/Fireball")]
public class MagicShot : Spell

{
    // public float flyDuration;
    // public float speed;
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

    void FireBall()
    {
        Debug.Log("Cast Fireball");
        Instantiate(magicProjectile, firePoint.position, firePoint.rotation);
    }
}
