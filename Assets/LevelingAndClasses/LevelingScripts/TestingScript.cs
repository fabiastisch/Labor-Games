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
    [Range(0,100)]public int vitallity = 10;
    [Range(0,100)]public int agillity = 10;
    [Range(0,100)]public int abillity = 20;
    [Range(0,100)]public int charisma = 30;
    [Range(0,100)]public int strength = 20;
    
    private Statistics stats;
    private void Start()
    {
       stats = new Statistics(strength, vitallity, charisma,abillity,agillity);
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
