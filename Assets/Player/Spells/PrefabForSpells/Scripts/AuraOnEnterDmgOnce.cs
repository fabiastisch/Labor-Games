using System.Collections.Generic;
using UnityEngine;

namespace Player.Spells.PrefabForSpells.Scripts
{
    public class AuraOnEnterDmgOnce: AuraBase
    {
        public override void TimeOption(List<Collider2D> enemyList)
        {
           //Nothing
        }

        public override void EnterOption(Collider2D other)
        {
           DoDmg(other.gameObject);
        }
    }
}