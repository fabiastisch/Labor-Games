using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeExample : MonoBehaviour
{
    //Time that is adjusted all the Time
    private float timer;
    //Time when something happens 3 -> every 3 Seconds
    private float timerMax;

    //here you can load timerMax from somewhere
    private void Awake()
    {
        //timerMax = classThatHasValue.timerMax;
    }
    
    void Update()
    {
        //use time do Subtract things
        timer -= Time.deltaTime;
        //after Time is over do something and restart Timer
        if (timer <= 0f)
        {
            timer += timerMax;
            Debug.Log("Something is Happening in this Time");
            //add something do Something
        }
    }
}
