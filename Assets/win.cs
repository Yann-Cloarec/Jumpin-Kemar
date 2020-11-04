using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    public GameObject win_screen;
    public Animator myAnimator;
    public Text final_time_win;
    public ParticleSystem particle;

    private void Start()
    {


    }

    private IEnumerator OnTriggerEnter(Collider col)
    {
        Timer timerObject = FindObjectOfType<Timer>();
        Mouvment player = FindObjectOfType<Mouvment>();
        if (col.tag.Equals("Player"))
        {
            win_screen.SetActive(true);
            player.winLevel();
            timerObject.stopTimer();
            this.final_time_win.text = timerObject.getElapsedTime();
            particle.Play();
            yield return new WaitForSeconds(3);
            win_screen.SetActive(false);

        }
    }
}
