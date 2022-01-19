using System.Collections.Generic;
using Player.Spells.TargetAndBuff;
using UnityEngine;

namespace Player.Passives.PassiveForClasses
{
    [CreateAssetMenu
        (menuName = "ScriptableObject/Passive/GiveBuffAfterMoveConditionForXTime")]
    public class PassiveBuffAfterNotMoving : LevelPassive
    {
        [Header("List of Buffs")] [SerializeField]
        private List<BuffStat.BuffValue> buffList = new List<BuffStat.BuffValue>();

        private bool active = false;

        public override void Activation(GameObject parent)
        {
            GiveBuff();
        }


        public override void BeginCooldown(GameObject parent)
        {
            GiveDebuff();
        }

        public override void Removed(GameObject parent)
        {
            GiveDebuff();
        }

        private void GiveBuff()
        {
            if (active) return;
            foreach (var VARIABLE in buffList)
            {
                StatManager.Instance.AddStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                    VARIABLE.valueOfBuff);
            }

            active = true;
        }

        private void GiveDebuff()
        {
            if (!active) return;
            foreach (var VARIABLE in buffList)
            {
                StatManager.Instance.RemoveStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                    VARIABLE.valueOfBuff);
            }
            active = false;
        }
    }
}