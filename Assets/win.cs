using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    public GameObject win_screen;
    public Animator myAnimator;

    private void Start()
    {


    }

    private IEnumerator OnTriggerEnter(Collider col)
    {
        Timer timerObject = FindObjectOfType<Timer>();
        Animator myAnimator = FindObjectOfType<Animator>();
        if (col.tag.Equals("Player"))
        {
            win_screen.SetActive(true);
            myAnimator.SetBool("isDancing", true);
            timerObject.stopTimer();
            yield return new WaitForSeconds(3);
            win_screen.SetActive(false);
        }
    }
}
