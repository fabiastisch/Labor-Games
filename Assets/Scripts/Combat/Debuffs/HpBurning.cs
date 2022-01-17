using Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Manager/DebuffType/HpBurn")]
public class HpBurning : DebuffTypeSO
{
    public float damagePerSecond;
    public DamageType damageType;
    private float timer = 0;

    public override void UpdateDebuff(Combat.Character character)
    {
        base.UpdateDebuff(character);
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            character.TakeDamage(damagePerSecond, character, damageType);
            timer = 0;
        }
    }

    public override void RemoveThisDebuff(Combat.Character character)
    {
        character.RemoveDebuff(this);
    }

}
