using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;
[CreateAssetMenu(menuName = "ScriptableObject/Manager/DebuffType/CasualDebuffEnemy")]
public class CasualEnemyDebuff : DebuffTypeSO
{
    private float tempValue;
    private float tempValue2;
    public enum EnemyDebuffs
    {
        Stun,
        Snare,
        Disarm,
        Slow,
        Freez,
    }
    public EnemyDebuffs debuff;

    private bool effectAppliedBefore = false;

    public override void UpdateDebuff(Combat.Character character)
    {
        if (currentlyApplied)
        {
            //Removing and activating debuff if already applied 
            if (effectAppliedBefore) ResetDebuff(character);
            ActivateDebuff(character);
        }
        base.UpdateDebuff(character);
    }

    public void ActivateDebuff(Combat.Character character)
    {
        Enemy enemy = (Enemy)character;
        effectAppliedBefore = true;
        switch (debuff)
        {
            case EnemyDebuffs.Disarm:
                tempValue = enemy.attackDamage;
                enemy.attackDamage = 0;
                break;
            case EnemyDebuffs.Slow:
                tempValue = enemy.movementSpeed;
                enemy.movementSpeed /= 20;
                break;
            case EnemyDebuffs.Freez:
                tempValue = enemy.attackDamage;
                enemy.attackDamage /= 20;
                tempValue2 = enemy.movementSpeed;
                enemy.movementSpeed /= 40;
                break;
            case EnemyDebuffs.Stun:
                tempValue = enemy.attackDamage;
                enemy.attackDamage = 0;
                tempValue2 = enemy.movementSpeed;
                enemy.movementSpeed = 0;
                break;
            case EnemyDebuffs.Snare:
                tempValue = enemy.movementSpeed;
                enemy.movementSpeed = 0;
                break;
        }
    }

    public void ResetDebuff(Combat.Character character)
    {
        Enemy enemy = (Enemy)character;
        switch (debuff)
        {
            case EnemyDebuffs.Disarm:
                enemy.attackDamage = tempValue;
                break;
            case EnemyDebuffs.Slow:
                enemy.movementSpeed = tempValue;
                break;
            case EnemyDebuffs.Freez:
                enemy.attackDamage = tempValue;
                enemy.movementSpeed = tempValue2;
                break;
            case EnemyDebuffs.Stun:
                enemy.attackDamage = tempValue;
                enemy.movementSpeed = tempValue2;
                break;
            case EnemyDebuffs.Snare:
                enemy.movementSpeed = tempValue;
                break;
        }
        effectAppliedBefore = false;
        Debug.Log("tmp1 " + tempValue + " tmp2 " + tempValue2);
    }

    public override void RemoveThisDebuff(Combat.Character character)
    {
        ResetDebuff(character);
        character.RemoveDebuff(this);
    }
}
