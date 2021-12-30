using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Agi/TrapAndSlowImmunity")]
public class Agi4 : LevelPassive
{
    public override void Activation(GameObject parent)
    {
        StatManager.Instance.SetBool(16); //TrapImmunity
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveBool(16);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveBool(16);
    }
}
