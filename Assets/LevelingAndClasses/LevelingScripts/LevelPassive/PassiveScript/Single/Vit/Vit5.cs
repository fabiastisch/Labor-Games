using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using LevelingAndClasses.LevelingScripts.LevelPassive.PassiveScript.Single.Vit;
using UnityEditor;
using UnityEngine;
using Utils;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Vit/HitBack")]
public class Vit5 : LevelPassive
{
    [SerializeField] private float reflectionPercentage = 0.25f;
    
    public override void Activation(GameObject parent)
    {
        GameObject player = Util.GetLocalPlayer().gameObject;
        player.AddComponent<ReflectDmg>();
        player.GetComponent<ReflectDmg>().percentThrowback = reflectionPercentage;
    }

    public override void Removed(GameObject parent)
    {
        Destroy(Util.GetLocalPlayer().gameObject.GetComponent<ReflectDmg>());
    }
}
