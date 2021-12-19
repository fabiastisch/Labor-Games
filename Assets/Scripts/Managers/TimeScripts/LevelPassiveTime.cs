using UnityEngine;

public class LevelPassiveTime : MonoBehaviour
{
    //Time that is adjusted all the Time
    private float timer;
    //Time when something happens 3 -> every 3 Seconds
    private float timerMax;

    public bool timeFunctionConnected = false;
    
    public bool active = false;
    
    private LevelPassiveListChecker _levelPassiveListChecker;


    private void Start()
    {
        _levelPassiveListChecker = gameObject.GetComponent<LevelPassiveListChecker>();
    }

    void Update()
    {
        if (timeFunctionConnected)
        {
            //use time do Subtract things
            timer -= Time.deltaTime;
            //after Time is over do something and restart Timer
            if (timer <= 0f)
            {
                _levelPassiveListChecker.TimeActivation();
                TimeReset();
            }
        }
    }

    public void TimeReset()
    {
        timer = timerMax;
    }

    public void SetTimer()
    {
        timeFunctionConnected = true;
    }
    
    public void RemoveTimer()
    {
        timeFunctionConnected = false;
    }

    public void SetMaxCooldown(float amount)
    {
        timerMax = amount;
    }

    public void SetCooldown(float amount)
    {
        timer = amount;
    }

    /**
     * Percentage between 0 and 1
     */
    public void RemovePrecentageFromTimer(float percentageAmount)
    {
        timer -= timer * percentageAmount;
    }
    
    /**
     * Percentage between 0 and 1
     */
    public void AddPrecentageToTimer(float percentageAmount)
    {
        timer += timer * percentageAmount;
    }

}
