using UnityEngine;

namespace Player.Spells.TargetAndBuff
{
    public class BuffStat: BuffMaker
    {
        [SerializeField] private StatType typeToBuff;
        [SerializeField] private float valueOfBuff;
        
        public override void Buff()
        {
            StatManager.Instance.AddStat(StatManager.Instance.statTypeList.list[(int) typeToBuff], valueOfBuff);
        }

        public override void Debuff()
        {
            StatManager.Instance.RemoveStat(StatManager.Instance.statTypeList.list[(int) typeToBuff], valueOfBuff);
        }
    }
}