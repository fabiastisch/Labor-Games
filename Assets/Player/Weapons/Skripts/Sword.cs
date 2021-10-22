using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    [SerializeField] private float swordDamage = 5f;
    [SerializeField] private float swordAttackspeed = 10f;
    [SerializeField] private float swordRange= 1f;
    [SerializeField] private float swordAOERange = 10f;

    // Start is called before the first frame update
    void Start()
    {
        baseDamage = swordDamage;
        baseAttackspeed = swordAttackspeed;
        baseRange = swordRange;
        baseAOERange = swordAOERange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

}
