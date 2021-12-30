using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Cha/StealthBool")]
public class Cha2 : LevelPassive
{
    public override void Activation(GameObject parent)
    {
        StatManager.Instance.SetBool(15); //StealthBool
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveBool(15);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveBool(15);
    }
}
