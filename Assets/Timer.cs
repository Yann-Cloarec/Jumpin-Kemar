using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{

    public Text text;
    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
    private string elapsed = "";
    private bool stop = false;

    void Update()
    {
        UpdateTimerUI();
    }
    //call this on update
    public void UpdateTimerUI()
    {
        if (!stop)
        {
            secondsCount += Time.deltaTime;
            text.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
            if (secondsCount >= 60)
            {
                minuteCount++;
                secondsCount = 0;

            }
            else if (minuteCount >= 60)
            {
                hourCount++;
                minuteCount = 0;
            }

            elapsed = text.text;
        }
       
    }

    public string getElapsedTime()
    {
        return this.elapsed;
    }

    public void reset()
    {
        this.secondsCount = 0;
        this.hourCount = 0;
        this.minuteCount = 0;
        this.stop = false;
    }

    public void stopTimer()
    {
        this.stop = true;
    }

    public void startTimer()
    {
        this.stop = false;
    }

}
