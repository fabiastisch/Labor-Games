using UnityEngine;
using Utils;

namespace Player.Passives.PassiveForClasses
{
    [CreateAssetMenu(menuName = "ScriptableObject/Passive/KillPassiveHeal")]
    public class PassiveAfterXKillsHeal : LevelPassive
    {
        [SerializeField] private float attacksNeeded = 10;
        [SerializeField] private float actualAttacks = 0;

        [SerializeField] private float heal = 20;
        [SerializeField] private float factorOfHp = 0.05f;
        
        

        //Gets the dead player
        public override void Activation(GameObject parent)
        {
            actualAttacks++;
            if (actualAttacks >= attacksNeeded)
            {
                actualAttacks = 0;

                if (heal > ActualStatsThatGetUsed.Instance.actualHP * factorOfHp)
                {
                     Util.GetLocalPlayer().Heal(heal);
                }
                else
                {
                    Util.GetLocalPlayer().Heal(ActualStatsThatGetUsed.Instance.actualHP * factorOfHp);
                }
                   
            }
        }
    }
}