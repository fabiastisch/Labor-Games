using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Str/DoubleAttackBool")]
public class Str5 : LevelPassive
{
    public override void Activation(GameObject parent)
    {
        StatManager.Instance.SetBool(14); //DoubleAttackBool
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveBool(14);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveBool(14);
    }
}
