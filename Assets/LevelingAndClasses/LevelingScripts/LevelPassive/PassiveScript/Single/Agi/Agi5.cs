using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Agi/Evade")]
public class Agi5 : LevelPassive
{
    public float evadeChance = 40f;
    private StatTypeListSO statTypeList;

    private void Awake()
    {
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }

    public override void Activation(GameObject parent)
    {
        StatManager.Instance.AddStat(statTypeList.list[6], evadeChance);
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[6], evadeChance);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[6], evadeChance);
    }
}
