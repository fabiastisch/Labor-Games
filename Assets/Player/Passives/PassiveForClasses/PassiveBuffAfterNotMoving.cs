using System.Collections.Generic;
using System.Linq;
using Player.Spells.TargetAndBuff;
using UnityEngine;
using Utils;

namespace Player.Passives.PassiveForClasses
{
    [CreateAssetMenu
        (menuName = "ScriptableObject/Passive/GiveBuffAfterMoveConditionForXTime")]
    public class PassiveBuffAfterNotMoving : LevelPassive
    {
        [Header("List of Buffs")] [SerializeField]
        private List<BuffStat.BuffValue> buffList = new List<BuffStat.BuffValue>();

        private bool active = false;
        
        [SerializeField] private GameObject buffObject;
        
        private List<GameObject> collection = new List<GameObject>();

        public override void Activation(GameObject parent)
        {
            GiveBuff();
        }


        public override void BeginCooldown(GameObject parent)
        {
            GiveDebuff();
        }

        public override void Removed(GameObject parent)
        {
            GiveDebuff();
        }

        private void GiveBuff()
        {
            if (active) return;
            foreach (var VARIABLE in buffList)
            {
                StatManager.Instance.AddStat(StatManager.Instance.statTypeList.list[(int) VARIABLE.typeToBuff],
                    VARIABLE.valueOfBuff);
            }
            GameObject aoe = Instantiate(buffObject, Util.GetLocalPlayer().transform.position, Quaternion.identity);
            aoe.transform.parent = Util.GetLocalPlayer().transform;
            collection.Add(aoe);

            active = true;
        }

        private void GiveDebuff()
        {
            if (!active) return;
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
            collection.Clear();
            active = false;
        }
    }
}