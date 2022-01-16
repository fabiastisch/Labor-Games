using System.Collections.Generic;
using Player.Spells.TargetAndBuff;
using UnityEngine;

namespace Player.Spells.PrefabForSpells.Scripts
{
    public class AreaOfBuffs : AuraBase
    {
        [Header("List of Buffs")] [SerializeField]
        private List<BuffStat.BuffValue> buffList = new List<BuffStat.BuffValue>();
        
        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 7)
            {
                foreach (var VARIABLE in buffList)
                {
                    StatManager.Instance.AddStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff], VARIABLE.valueOfBuff);
                }
            }
        }

        public override void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == 7)
            {
                foreach (var VARIABLE in buffList)
                {
                    StatManager.Instance.RemoveStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff], VARIABLE.valueOfBuff);
                }
            }
        }
        
    }
}