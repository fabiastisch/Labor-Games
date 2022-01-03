using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Abi/CooldownReduction")]
public class Abi1 : LevelPassive
{
    public float cooldownreduction = 15f;
    private StatTypeListSO statTypeList;

    private void Awake()
    {
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }

    public override void Activation(GameObject parent)
    {
        StatManager.Instance.AddStat(statTypeList.list[4], cooldownreduction);
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[4], cooldownreduction);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[4], cooldownreduction);
    }
}
