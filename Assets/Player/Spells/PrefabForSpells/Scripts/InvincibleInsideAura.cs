using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Player.Spells.PrefabForSpells.Scripts
{
    public class InvincibleInsideAura : AuraBase
    {
        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (enemyList.Contains(other)) return;
            //player Layer
            if (other.gameObject.layer == 7)
            {
                enemyList.Add(other);
                Util.GetLocalPlayer().Invulnerable = true;
            }
        }

        public override void OnTriggerExit2D(Collider2D other)
        {
            if (enemyList.Contains(other))
            {
                if (other.gameObject.layer == 7)
                {
                    enemyList.Remove(other);
                    Util.GetLocalPlayer().Invulnerable = false;
                }
            }
               
        }

        public override void TimeOption(List<Collider2D> enemyList)
        {
        }

        public override void BeforeDestroy()
        {
            Util.GetLocalPlayer().Invulnerable = false;
        }
    }
}