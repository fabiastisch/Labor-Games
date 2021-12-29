using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

[CreateAssetMenuAttribute(menuName = "ScriptableObject/Spell/Fireball")]
public class MagicShot : Spell

{
    // public float flyDuration;
    // public float speed;
    //I cant Drag a Scene Object into here so i need to initialize it in the script

    // [SerializeField] private Animation CastAnimation;
    

    public override void Activation(GameObject parent)
    {
        FireBall();
    }

    void FireBall()
    {
        GameObject player = Util.GetLocalPlayer().gameObject;
        
        Debug.Log("Cast Fireball");
        Instantiate(magicProjectile, player.transform.position, player.GetComponent<MouseTrack>().GetRotationToMouse());
    }
}
