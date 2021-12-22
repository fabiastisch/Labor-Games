using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Cha/StunChance")]
public class Cha1 : LevelPassive
{
    public float stunchance = 10f;
    private StatTypeListSO statTypeList;

    private void Awake()
    {
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }

    public override void Activation(GameObject parent)
    {
        StatManager.Instance.AddStat(statTypeList.list[10], stunchance);
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[10], stunchance);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[10], stunchance);
    }
}
