using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LevelingAndClasses.LevelingScripts.Passives.PassiveScripts
{
    [CreateAssetMenuAttribute(menuName = "Passives/EvadeChance")]
    public class EvadeChance : Passive
    {
        public float evadeChance = 40f;

        private StatTypeListSO statTypeList;

        private void Awake()
        {
            statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
        }

        public override void Activation(GameObject parent)
        {
            Debug.Log("EvadeChance Perk Activation");

            // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
            //
            // player.stunChance += stunChance;
            //
            // player.GetStats();
            StatManager.Instance.AddStat(statTypeList.list[6], evadeChance);

        }

        public override void BeginCooldown(GameObject parent)
        {
            Debug.Log("EvadeChance deactivated");

            // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
            //
            // player.stunChance -= stunChance;
            //
            // player.GetStats();
            StatManager.Instance.RemoveStat(statTypeList.list[6], evadeChance);



        }
    }
}