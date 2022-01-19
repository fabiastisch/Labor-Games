using System.Collections;
using System.Collections.Generic;
using Player.Spells.TargetAndBuff;
using UnityEngine;

public class PassiveGivesStat : LevelPassive
{
    [Header("List of Buffs")] [SerializeField]
    private List<BuffStat.BuffValue> buffList = new List<BuffStat.BuffValue>();


    public override void Activation(GameObject parent)
    {
        foreach (var VARIABLE in buffList)
        {
            StatManager.Instance.AddStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                VARIABLE.valueOfBuff);
        }
    }

    public override void Removed(GameObject parent)
    {
        foreach (var VARIABLE in buffList)
        {
            StatManager.Instance.RemoveStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                VARIABLE.valueOfBuff);
        }
    }
}
