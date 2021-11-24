using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShot : Passive

{
    public float flyDuration;
    public float speed;
    [SerializeField] private GameObject magicProjectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Animation CastAnimation;
    
    public override void Activation(GameObject parent)
    {
        FireBall();
        base.Activation(parent);
    }

    public override void BeginCooldown(GameObject parent)
    {
        base.BeginCooldown(parent);
    }

    void FireBall()
    {
        Instantiate(magicProjectile, firePoint.position, firePoint.rotation);
    }
}
