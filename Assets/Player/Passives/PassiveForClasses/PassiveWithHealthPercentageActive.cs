using System.Collections.Generic;
using Player.Spells.TargetAndBuff;
using UnityEngine;
using Utils;

namespace Player.Passives.PassiveForClasses
{
    [CreateAssetMenu(menuName = "ScriptableObject/Passive/PassiveHealthConditions")]
    public class PassiveWithHealthPercentageActive : LevelPassive
    {
        [Header("List of Buffs")] [SerializeField]
        private List<BuffStat.BuffValue> buffList = new List<BuffStat.BuffValue>();

        [SerializeField] private float hpPercentage = 0.80f;
        [SerializeField] private bool isOverPercentage = true;

        /**
         * should be in normalCase false
         */
        [SerializeField] private bool active = false;

        public override void Activation(GameObject parent)
        {
            if (isOverPercentage)
            {
                if (Util.GetLocalPlayer().GetPercentageHpSmall() > hpPercentage)
                {
                    GiveBuff();
                }
                else if (active)
                {
                    GiveDebuff();
                }
            }
            else if (!isOverPercentage)
            {
                if (Util.GetLocalPlayer().GetPercentageHpSmall() < hpPercentage)
                {
                    GiveBuff();
                }
                else if (active)
                {
                    GiveDebuff();
                }
            }
        }

        public override void BeginCooldown(GameObject parent)
        {
            base.BeginCooldown(parent);
        }

        public override void Removed(GameObject parent)
        {
            if (active)
            {
                GiveDebuff();
            }
        }

        private void GiveBuff()
        {
            foreach (var VARIABLE in buffList)
            {
                StatManager.Instance.AddStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                    VARIABLE.valueOfBuff);
            }

            active = true;
        }
        
        private void GiveDebuff()
        {
            foreach (var VARIABLE in buffList)
            {
                StatManager.Instance.RemoveStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                    VARIABLE.valueOfBuff);
            }

            active = false;
        }
    }
}