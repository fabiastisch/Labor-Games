using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_RadarChart : MonoBehaviour
{
  private Statistics statistics;

  public void SetStatistic(Statistics statistics)
  {
    this.statistics = statistics;
    statistics.OnStatisticChange += Statistics_OnStatisticChange;
    UpdateStatsVisual();
  }
  private void Statistics_OnStatisticChange(object sender, System.EventArgs e)
  {
    
  }

  private void UpdateStatsVisual()
  {
    transform.Find("VitallityBar").localScale = new Vector3(1, statistics.GetPersentageAmount(Statistics.Type.Vitallity));
    transform.Find("StrengthBar").localScale = new Vector3(1, statistics.GetPersentageAmount(Statistics.Type.Strength));
    transform.Find("CharismaBar").localScale = new Vector3(1, statistics.GetPersentageAmount(Statistics.Type.Charisma));
    transform.Find("AbillityBar").localScale = new Vector3(1, statistics.GetPersentageAmount(Statistics.Type.Abillity));
    transform.Find("AgillityBar").localScale = new Vector3(1, statistics.GetPersentageAmount(Statistics.Type.Agillity));
  }
}
