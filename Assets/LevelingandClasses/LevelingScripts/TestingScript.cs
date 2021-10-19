using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TestingScript : MonoBehaviour
{  
    [SerializeField] private UI_RadarChart uiStatsRadarChart;
    
    //if we want to add the Buttons manually and not via Unity
    /*
    public Button vitallityButton = GameObject.Find("vitallityButton").GetComponent<Button>();
    public Button agillityButton = GameObject.Find("agillityButton").GetComponent<Button>();
    public Button abillityButton = GameObject.Find("abillityButton").GetComponent<Button>();
    public Button charismaButton = GameObject.Find("charismaButton").GetComponent<Button>();
    public Button strengthButton = GameObject.Find("strengthButton").GetComponent<Button>();
    */
    
    
    private Statistics stats;
    private void Start()
    {
       stats = new Statistics(10, 10, 10,0,10);
       uiStatsRadarChart.SetStatistic(stats);
    }
   public void IncreaseStat(string name){
       switch (name)
       {
           case "vitallity":  stats.IncreaseStatAmount(Statistics.Type.Vitallity);
               break;
           case "agillity":  stats.IncreaseStatAmount(Statistics.Type.Agillity);
               break;
           case "abillity":  stats.IncreaseStatAmount(Statistics.Type.Abillity);
               break;
           case "charisma":  stats.IncreaseStatAmount(Statistics.Type.Charisma);
               break;
           case "strength":  stats.IncreaseStatAmount(Statistics.Type.Strength);
               break;
       }
       
   }
    
}
