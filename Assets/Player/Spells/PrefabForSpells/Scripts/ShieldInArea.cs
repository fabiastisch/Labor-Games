using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Utils;

namespace Player.Spells.PrefabForSpells.Scripts
{
    public class ShieldInArea : AuraBase
    {
        
        
        private List<GameObject> playerInCollection = new List<GameObject>();
        
        [SerializeField] private Shield shield;

        [SerializeField] private bool OnlyOnPlayerThroughDuration = true;

        public override void TimeOption(List<Collider2D> enemyList)
        {
            if (OnlyOnPlayerThroughDuration)
            {
                AddShieldToPlayer(Util.GetLocalPlayer().gameObject);
            }
        }

        public override void BeforeDestroy()
        {
            if (playerInCollection.Any())
            {
                foreach (var VARIABLE in playerInCollection)
                {
                    RemoveShield(VARIABLE);
                }
            }
        }
        
        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 7)
            {
                if (!playerInCollection.Contains(other.gameObject))
                {
                    playerInCollection.Add(other.gameObject);
                    AddShieldToPlayer(other.gameObject);
                }
            }
        }

        public override void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == 7)
            {
                if (playerInCollection.Contains(other.gameObject))
                {
                    playerInCollection.Remove(other.gameObject);
                    RemoveShield(other.gameObject);
                }
            }
        }

        public void AddShieldToPlayer(GameObject other)
        {
            if (shield == null)
            {
                
                if (ActualStatsThatGetUsed.Instance.actualHP == 0)
                {
                    shield = new Shield(baseDamage);
                }
                else
                    shield = new Shield(ActualStatsThatGetUsed.Instance.actualHP * factor);
            
                other.gameObject.GetComponent<Combat.Character>().AddShield(shield);
            }
            else
            {
                shield.RefreshShield();
            }
        }
        
        public void RemoveShield(GameObject other)
        {
            if (shield == null)
            {
                if (other.GetComponent<Combat.Character>().shields.HasThisShield(shield))
                    other.GetComponent<Combat.Character>().shields.Remove(shield);
            }
        }
        
    }
    
}