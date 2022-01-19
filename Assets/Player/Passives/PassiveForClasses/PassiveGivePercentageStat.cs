using System.Collections.Generic;
using System.Linq;
using Player.Spells.TargetAndBuff;
using UnityEngine;

    [CreateAssetMenu
        (menuName = "ScriptableObject/Passive/GiveStatPercentage")]
    public class PassiveGivePercentageStat : LevelPassive
    {
        [Header("List of Buffs")] [SerializeField]
        private List<BuffStat.BuffValue> buffList = new List<BuffStat.BuffValue>();

        private List<float> removeReferenz = new List<float>();


        public override void Activation(GameObject parent)
        {
            foreach (var VARIABLE in buffList)
            {
                float bonus = StatManager.Instance.GetStat(
                    StatManager.Instance.statTypeList.list[(int) VARIABLE.valueForFactorReferenz]) * VARIABLE.factor;
                removeReferenz.Add(bonus);

                StatManager.Instance.AddStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                    bonus);
            }
        }

        public override void Removed(GameObject parent)
        {
            if (!removeReferenz.Any())
                return;

            for (int counter = 0; counter < buffList.Count; counter++)
            {
                StatManager.Instance.RemoveStat(
                    StatManager.Instance.statTypeList.list[(int) buffList[counter].typeToBuff],
                    removeReferenz[counter]);
            }

            EmptyReferenz();
        }

        private void EmptyReferenz()
        {
            removeReferenz.Clear();
        }
    }