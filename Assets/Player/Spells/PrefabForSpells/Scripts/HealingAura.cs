using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Player.Spells.PrefabForSpells
{
    public class HealingAura:AuraBase
    {

        [SerializeField] private bool player = true;
        [SerializeField] private bool enemy = false;
        
        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (enemyList.Contains(other)) return;

            if (player && other.gameObject.layer == 7)
            {
                enemyList.Add(other);
            }
            
            if (enemy && other.gameObject.layer == 6)
            {
                enemyList.Add(other);
            }
        }

        public override void OnTriggerExit2D(Collider2D other)
        {
            if (enemyList.Contains(other))
                enemyList.Remove(other);
        }

        public override void TimeOption(List<Collider2D> enemyList)
        {
            Debug.Log("Healing Aura Effect");
            foreach (var VARIABLE in enemyList)
            {
                    GameObject healingObject = VARIABLE.gameObject;
                    
                    healingObject.gameObject.GetComponent<Combat.Character>().Heal(damage);
            }
        }
    }
}