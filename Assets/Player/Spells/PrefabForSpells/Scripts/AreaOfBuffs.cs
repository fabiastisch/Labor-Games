using System.Collections.Generic;
using System.Linq;
using Player.Spells.TargetAndBuff;
using UnityEngine;

namespace Player.Spells.PrefabForSpells.Scripts
{
    public class AreaOfBuffs : AuraBase
    {
        private List<GameObject> playerInCollection = new List<GameObject>();
        [Header("List of Buffs")] [SerializeField]
        private List<BuffStat.BuffValue> buffList = new List<BuffStat.BuffValue>();

        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 7)
            {
                if (!playerInCollection.Contains(other.gameObject))
                {
                    playerInCollection.Add(other.gameObject);
                    foreach (var VARIABLE in buffList)
                    {
                        StatManager.Instance.AddStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                            VARIABLE.valueOfBuff);
                    }
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
                    foreach (var VARIABLE in buffList)
                    {
                        StatManager.Instance.RemoveStat(
                            StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff], VARIABLE.valueOfBuff);
                    }
                }
            }
        }

        public override void BeforeDestroy()
        {
            if (playerInCollection.Any())
            {
                foreach (var VARIABLE in buffList)
                {
                    StatManager.Instance.RemoveStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                        VARIABLE.valueOfBuff);
                }
            }
        }
        
    }
}