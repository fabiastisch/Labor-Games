using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Agi/Movementspeed")]
public class Agi1 : LevelPassive
{
    public float movementspeed = 1f;
    private StatTypeListSO statTypeList;

    private void Awake()
    {
        statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
    }

    public override void Activation(GameObject parent)
    {
        StatManager.Instance.AddStat(statTypeList.list[9], movementspeed);
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[9], movementspeed);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveStat(statTypeList.list[9], movementspeed);
    }
}
