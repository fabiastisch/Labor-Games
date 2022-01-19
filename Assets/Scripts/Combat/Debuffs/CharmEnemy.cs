using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;

[CreateAssetMenu(menuName = "ScriptableObject/Manager/DebuffType/CharmEnemy")]
public class CharmEnemy : DebuffTypeSO
{   /*
    //Enemylayer 6
    private LayerMask enemyLayer;
    //Playerlayer 7
    private LayerMask playerLayer;
    //CharmedLayer 10
    private LayerMask charmedLayer;

    private AIPlayerDetector aiDetector;
    private LayerMask currentEnemyLayer;

    private bool effectAppliedBefore = false;

    public void OnEnable()
    {
        enemyLayer = LayerMask.GetMask("Enemy");
        playerLayer = LayerMask.GetMask("Player");
        charmedLayer = LayerMask.GetMask("CharmedEnemy");
    }

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
        effectAppliedBefore = true;
        Enemy enemy = (Enemy)character;
        aiDetector = enemy.GetComponent<AIPlayerDetector>();
        currentEnemyLayer = enemy.gameObject.layer;
        currentEnemyLayer = charmedLayer;
        aiDetector.detectorLayerMask = enemyLayer;
    }

    public void ResetDebuff(Combat.Character character)
    {
        currentEnemyLayer = enemyLayer;
        aiDetector.detectorLayerMask = playerLayer;
        effectAppliedBefore = false;
    }

    public override void RemoveThisDebuff(Combat.Character character)
    {
        ResetDebuff(character);
        character.RemoveDebuff(this);
    }
    */
}
