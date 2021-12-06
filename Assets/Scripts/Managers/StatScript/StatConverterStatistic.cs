using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatConverterStatistic : MonoBehaviour
{

   //This Class converts the Level Up to Actually Values in the Dictionary -> We can add here other Values
   private StatTypeListSO statTypeList;

   private void Awake()
   { 
      statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
   }

   
   // private void Start()
   // {
   //    Statistics.Instance.OnStatisticChange += StatisticChanges;
   //    
   // }
   //
   // private void StatisticChanges(object sender, System.EventArgs e)
   // {
   //    throw new System.NotImplementedException();
   // }
   

   public void VitallityScale()
   {
      float hpPerLevel = 10f; //Max hp Stat 8
      //float armorPerLevel = 5;
      //float magicResistPerLevel = 5;
      
      StatManager.Instance.AddStat(statTypeList.list[8], hpPerLevel);
      //StatManager.Instance.AddStat(statTypeList.list[8], armorPerLevel);
      //StatManager.Instance.AddStat(statTypeList.list[8], magicResistPerLevel);
   }
   
   public void AbillityScale()
   {
      float abillityScalingPerLevel = 10f; //AbillityScaling Stat 0
     
      
      StatManager.Instance.AddStat(statTypeList.list[0], abillityScalingPerLevel);
   }
   
   public void CharismaScale()
   {
      float charismaPerLevel = 5f; //Charisma Stat 13
      
      StatManager.Instance.AddStat(statTypeList.list[13], charismaPerLevel);
   }
   
   public void StrengthScale()
   {
      float strengthPerLevel = 10f; //Max hp Stat 1
      
      StatManager.Instance.AddStat(statTypeList.list[1], strengthPerLevel);
      
   }
   
   public void AgillityScale()
   {
      float movementspeedPerLevel = 0.5f; //Movement Stat 9
      float attackspeedPerLevel = 0.2f; //Attackspeed Stat 2
      
      StatManager.Instance.AddStat(statTypeList.list[9], movementspeedPerLevel);
      StatManager.Instance.AddStat(statTypeList.list[2], attackspeedPerLevel);
   }
   
   
}
