using UnityEngine;

[CreateAssetMenuAttribute( menuName = "LevelPassive/Single/Abi/ReduceCooldownOnCast")]
public class Abi4 : LevelPassive
{
    [SerializeField] [Range(0f, 1f)] private float percentage;
    public override void Activation(GameObject parent)
    {
        SpellHoldChecker.Instance.ReduceCooldown(percentage);
    }
    
}
