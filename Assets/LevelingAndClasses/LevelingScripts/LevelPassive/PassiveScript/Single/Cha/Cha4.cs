using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Cha/Charm")]
public class Cha4 : LevelPassive
{
    public float charmChance = 30f;
    private StatTypeListSO statTypeList;

    private void Awake()
    {
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }

    public override void Activation(GameObject parent)
    {
        StatManager.Instance.AddStat(statTypeList.list[3], charmChance);
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[3], charmChance);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[3], charmChance);
    }
}
