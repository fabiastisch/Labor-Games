using Combat;
using UnityEngine;
using Utils;

namespace Player.Passives.PassiveForClasses
{
    [CreateAssetMenu(menuName = "ScriptableObject/Passive/KillGivesShield")]
    public class PassiveKillGivesShield : LevelPassive
    {
        [SerializeField] private float maxShield = 250f;
        [SerializeField] private Shield shield;
        [SerializeField] private float baseShield = 5f;
        [SerializeField] private float maxHpFactor = 0.01f;

        public override void Activation(GameObject parent)
        {
            AddShieldToPlayer(Util.GetLocalPlayer().gameObject);
        }
        
        public void AddShieldToPlayer(GameObject other)
        {
            if (shield == null)
            {
                
                if (ActualStatsThatGetUsed.Instance.actualHP == 0)
                {
                    shield = new Shield(baseShield, maxShield);
                }
                else
                    shield = new Shield(ActualStatsThatGetUsed.Instance.actualHP * maxHpFactor, maxShield);
            
                other.gameObject.GetComponent<Combat.Character>().AddShield(shield);
            }
            else
            {
                if (shield.shieldingValue < maxShield)
                {
                    float endValue = shield.shieldingValue + ActualStatsThatGetUsed.Instance.actualHP * maxHpFactor;

                    if (endValue > maxShield)
                    {
                       shield.RefreshShield();
                    }
                    else
                        shield.AddShielding(ActualStatsThatGetUsed.Instance.actualHP * maxHpFactor);
                }
            }
        }
    }
}