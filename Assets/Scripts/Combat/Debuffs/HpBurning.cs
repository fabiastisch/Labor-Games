using Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Manager/DebuffType/HpBurn")]
public class HpBurning : DebuffTypeSO
{
    public float damagePerSecond;
    public DamageType damageType;
    public override void MakeDamage(Combat.Character character)
    {
        character.TakeDamage(damagePerSecond, character, damageType);
    }
}
