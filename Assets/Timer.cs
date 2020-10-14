using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text text;
    private string elapsed = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.SetGlobalTimer();
    }

    public void SetGlobalTimer()
    {
        string currentTime = Time.time.ToString("f6");
        elapsed = currentTime;
        currentTime = "Timer : " + currentTime + " sec.";
        text.text = currentTime;
    }

    public string getElapsedTime()
    {
        return this.elapsed;
    }

    public void stopTimer()
    {

    }

}
