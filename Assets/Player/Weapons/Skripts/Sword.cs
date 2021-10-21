using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeeleWeapon, ISwingable
{

    // Start is called before the first frame update
    void Start()
    {
        damage = 10f;
        attackspeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwingWeapon(float damage, float attackspeed)
    {
        Debug.Log("SwingSword dealt: "+damage+" attackspeed: "+attackspeed);
    }
}
