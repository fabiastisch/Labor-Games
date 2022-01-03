using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Str/FullLifePercentageDmg")]
public class Str4 : LevelPassive
{
    public override void Activation(GameObject parent)
    {
        StatManager.Instance.SetBool(22);
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveBool(22);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveBool(22);
    }
}
