using System.Collections.Generic;
using System.Linq;
using Player.Spells.TargetAndBuff;
using UnityEngine;
using Utils;

namespace Player.Passives.PassiveForClasses
{
    [CreateAssetMenu(menuName = "ScriptableObject/Passive/PassiveHealthConditions")]
    public class PassiveWithHealthPercentageActive : LevelPassive
    {
        [Header("List of Buffs")] [SerializeField]
        private List<BuffStat.BuffValue> buffList = new List<BuffStat.BuffValue>();

        [SerializeField] private float hpPercentage = 0.80f;
        [SerializeField] private bool isOverPercentage = true;
        [SerializeField] private GameObject buffObject;
        
        private List<GameObject> collection = new List<GameObject>();
        

        /**
         * should be in normalCase false
         */
        [SerializeField] private bool active = false;

        public override void Activation(GameObject parent)
        {
            if (isOverPercentage)
            {
                if (Util.GetLocalPlayer().GetPercentageHpSmall() > hpPercentage)
                {
                    GiveBuff();
                }
                else if (active)
                {
                    GiveDebuff();
                }
            }
            else if (!isOverPercentage)
            {
                if (Util.GetLocalPlayer().GetPercentageHpSmall() < hpPercentage)
                {
                    GiveBuff();
                }
                else if (active)
                {
                    GiveDebuff();
                }
            }
        }

        public override void BeginCooldown(GameObject parent)
        {
            base.BeginCooldown(parent);
        }

        public override void Removed(GameObject parent)
        {
            if (active)
            {
                GiveDebuff();
            }
        }

        private void GiveBuff()
        {
            foreach (var VARIABLE in buffList)
            {
                StatManager.Instance.AddStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                    VARIABLE.valueOfBuff);
            }
            GameObject aoe = Instantiate(buffObject, Util.GetLocalPlayer().transform.position, Quaternion.identity);
            collection.Add(aoe);

            active = true;
        }
        
        private void GiveDebuff()
        {
            foreach (var VARIABLE in buffList)
            {
                StatManager.Instance.RemoveStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                    VARIABLE.valueOfBuff);
            }
            
            if (!collection.Any())
            {
                return;
            }
   
            for (int counter = collection.Count - 1; counter >= 0; counter--)
            {
                if (collection[counter] != null)
                {
                    GameObject other = collection[counter].gameObject;
                    Destroy(other.gameObject);
                }
            }

            active = false;
        }
    }
}