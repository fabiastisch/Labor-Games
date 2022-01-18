using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class StatisticValue : MonoBehaviour
{
    [SerializeField] private UI_RadarChart uiStatsRadarChart;
    [SerializeField] private Text uiLevelCounter;
    //if we want to add the Buttons manually and not via Unity
    /*
    public Button vitallityButton = GameObject.Find("vitallityButton").GetComponent<Button>();
    public Button agillityButton = GameObject.Find("agillityButton").GetComponent<Button>();
    public Button abillityButton = GameObject.Find("abillityButton").GetComponent<Button>();
    public Button charismaButton = GameObject.Find("charismaButton").GetComponent<Button>();
    public Button strengthButton = GameObject.Find("strengthButton").GetComponent<Button>();
    */

    public Statistics stats;

    private float levelPoints;
    private float pointsUsed;
    private float level;

    private void Start()
    {
        stats = Statistics.Instance;
        uiStatsRadarChart.SetStatistic(stats);
        Util.GetLocalPlayer().GetComponent<PlayerLevelManager>().OnLevelChanged += OnLevelChanged;
    }

    private void OnLevelChanged(int obj)
    {
        level = obj;
        levelPoints += 1;
        SetLevelPointText();
    }
    

    public void IncreaseStat(string name)
    {
        if (!CheckForLevelPoints())
            return;

        switch (name)
        {
            case "vitallity":
                if (stats.IncreaseStatAmount(Statistics.Type.Vitallity))
                {
                    StatConverterStatistic.Instance.VitallityScale();
                    UsedPoint();
                }
                break;
            case "agillity":
                if (stats.IncreaseStatAmount(Statistics.Type.Agillity))
                {
                    StatConverterStatistic.Instance.AgillityScale();
                    UsedPoint();
                }
                break;
            case "abillity":
                if (stats.IncreaseStatAmount(Statistics.Type.Abillity))
                {
                    StatConverterStatistic.Instance.AbillityScale();
                    UsedPoint();
                }
                break;
            case "charisma":
                if (stats.IncreaseStatAmount(Statistics.Type.Charisma))
                {
                    StatConverterStatistic.Instance.CharismaScale();
                    UsedPoint();
                }
                break;
            case "strength":
                if (stats.IncreaseStatAmount(Statistics.Type.Strength))
                {
                    StatConverterStatistic.Instance.StrengthScale();
                    UsedPoint();
                }
                break;
        }
    }

    private bool CheckForLevelPoints()
    {
        return levelPoints > 0;
    }
    

    private void UsedPoint()
    {
        levelPoints -= 1;
        pointsUsed += 1;
        SetLevelPointText();
    }

    public void ResetStats()
    {
        levelPoints = level;
        pointsUsed = 0;
        SetLevelPointText();

        stats.SetStatisticAmount(Statistics.Type.Strength, 1);
        stats.SetStatisticAmount(Statistics.Type.Agillity, 1);
        stats.SetStatisticAmount(Statistics.Type.Charisma, 1);
        stats.SetStatisticAmount(Statistics.Type.Abillity, 1);
        stats.SetStatisticAmount(Statistics.Type.Vitallity, 1);
    }

    private void SetLevelPointText()
    {
        uiLevelCounter.text = levelPoints.ToString(CultureInfo.InvariantCulture);
    }
}