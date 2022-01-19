using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableObject/Manager/DebuffType/StatsDebuffPlayer")]
public class StatsDebuffPlayer : DebuffTypeSO
{
    [Serializable]
    public struct DebuffStats
    {
        public StatTypeSO statType;
        public float value;
    }

    public DebuffStats[] debuffList;
    public bool shouldBeProzentage = false;
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
        var myCharacter = character as Player.PlayerBase;
        if (myCharacter != null)
        {
            if (!shouldBeProzentage)
            {
                foreach (var item  in debuffList)
                {
                    StatManager.Instance.RemoveStat(item.statType, item.value);
                } 
            }
            else
            {
                foreach (var item in debuffList)
                {
                    StatManager.Instance.DivideStat(item.statType, item.value);
                }
            }
        }
        effectAppliedBefore = true;
    }

    public void ResetDebuff(Combat.Character character)
    {
        var myCharacter = character as Player.PlayerBase;
        if (myCharacter != null)
        {
            if (!shouldBeProzentage)
            {
                foreach (var item in debuffList)
                {
                    StatManager.Instance.AddStat(item.statType, item.value);
                }
            }
            else
            {
                foreach (var item in debuffList)
                {
                    StatManager.Instance.MultiplyStat(item.statType, item.value);
                }
            }
        }
        effectAppliedBefore = false;
    }

    public override void RemoveThisDebuff(Combat.Character character)
    {
        if (character == null) return;
        ResetDebuff(character);
        character.RemoveDebuff(this);
    }
}
