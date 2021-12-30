using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Abi/DoubleMagicDmg")]
public class Abi5 : LevelPassive
{
    public override void Activation(GameObject parent)
    {
        StatManager.Instance.SetBool(13); //DoubleMagicDmg
    }

    public override void BeginCooldown(GameObject parent)
    {
        StatManager.Instance.RemoveBool(13);
    }

    public override void Removed(GameObject parent)
    {
        StatManager.Instance.RemoveBool(13);
    }
}
