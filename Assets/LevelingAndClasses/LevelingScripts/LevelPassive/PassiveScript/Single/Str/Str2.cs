using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Str/Critchance")]
public class Str2 : LevelPassive
{
    public float critChance = 20f;
    private StatTypeListSO statTypeList;
    
    private void Awake()
    {
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }
    
    public override void Activation(GameObject parent)
    {
        StatManager.Instance.AddStat(statTypeList.list[5], critChance);
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[5], critChance);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[5], critChance);
    }
}
