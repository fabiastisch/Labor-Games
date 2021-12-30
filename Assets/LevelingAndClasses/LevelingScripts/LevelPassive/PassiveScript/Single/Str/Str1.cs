using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Str/Attackspeed")]
public class Str1 : LevelPassive
{
    public float attackspeedvalue = 1.2f;
    private StatTypeListSO statTypeList;

    private void Awake()
    {
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }

    public override void Activation(GameObject parent)
    {
        StatManager.Instance.AddStat(statTypeList.list[2], attackspeedvalue);
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[2], attackspeedvalue);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[2], attackspeedvalue);
    }
}
