using UnityEngine;

[CreateAssetMenuAttribute( menuName = "Passives/CharmChance")]
public class CharmChance : Passive
{
    public float charmChance = 15f;
         private StatTypeListSO statTypeList;
         private void Awake()
         { 
             statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
         }
         
         public override void Activation(GameObject parent)
         {
             Debug.Log("CharmChance Perk Activation");
             
             // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
             //
             // player.stunChance += stunChance;
             //
             // player.GetStats();
             StatManager.Instance.AddStat(statTypeList.list[3], charmChance);
     
         }
     
         public override void BeginCooldown(GameObject parent)
         {
             Debug.Log("CharmChance deactivated");
     
             // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
             //
             // player.stunChance -= stunChance;
             //
             // player.GetStats();
             StatManager.Instance.RemoveStat(statTypeList.list[3], charmChance);
             
             
             
         }
}
