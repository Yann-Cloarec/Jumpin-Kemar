using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Countdown : MonoBehaviour
{
    public float timeRemaining = 10;
    public Text cd;
    private Mouvment player;
    private Vector3 spawn;
    public Text textToHide;
    private void Start()
    {
        player = FindObjectOfType<Mouvment>();
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            setCountdown(Math.Round((decimal)timeRemaining, 0));
            player.Respawn();
        } else
        {
            cd.text = "";
            textToHide.text = "";
        }
    }
    public void setCountdown(decimal time)
    {
        cd.text = time.ToString();
    }
}
