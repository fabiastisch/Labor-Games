using System;
using Combat;
using UnityEngine;
using Utils;

namespace LevelingAndClasses.LevelingScripts.LevelPassive.PassiveScript.Single.Vit
{
    public class ReflectDmg : MonoBehaviour
    {

        public ReflectDmg(float reflectionrate)
        {
            percentThrowback = reflectionrate;
        }
        
        [SerializeField] public float percentThrowback = 0.25f;

        private void Awake()
        {
            Util.GetLocalPlayer().OnPlayerTakeDamage += OnOnPlayerTakeDamage; 
        }

        private void OnOnPlayerTakeDamage(Enemy arg1, DamageType arg2, float arg3, bool arg4)
        {
            Debug.Log("Inside Hitback");
            if (arg1.gameObject.layer == 6)
            {
                arg1.TakeDamage(arg3 * percentThrowback, arg1, DamageType.Physical , false);
                Debug.Log("ShouldHitBack");
            }
        }
    }
}