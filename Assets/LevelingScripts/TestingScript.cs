using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingScript : MonoBehaviour
{  
    [SerializeField] private UI_RadarChart uiStatsRadarChart;
    public Button button;
    private Statistics stats;
    private void Start()
    {
       stats = new Statistics(10, 40, 10,0,100);
       uiStatsRadarChart.SetStatistic(stats);
       Button btn = button.GetComponent<Button>();
       btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
        stats.IncreaseStatAmount(Statistics.Type.Vitallity);
    }
    
}
