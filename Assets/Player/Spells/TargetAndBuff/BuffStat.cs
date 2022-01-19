using System.Collections.Generic;
using UnityEngine;

namespace Player.Spells.TargetAndBuff
{
    [CreateAssetMenu(menuName = "ScriptableObject/Spell/Buffstat")]
    public class BuffStat: BuffMaker
    {
        [Header("List of Buffs")] [SerializeField]
        private List<BuffValue> buffList = new List<BuffValue>();

        public override void Buff()
        {
            foreach (var VARIABLE in buffList)
            {
                StatManager.Instance.AddStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff], VARIABLE.valueOfBuff);
            }
        }

        public override void Debuff()
        {
            foreach (var VARIABLE in buffList)
            {
                StatManager.Instance.RemoveStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff], VARIABLE.valueOfBuff);
            }
        }
        
        [System.Serializable]
        public class BuffValue
        {
            [SerializeField] public StatType typeToBuff;
            [SerializeField] public float valueOfBuff;

            [SerializeField] public StatType valueForFactorReferenz;
            [SerializeField] public float factor = 0.1f;
        }
    }

    
}