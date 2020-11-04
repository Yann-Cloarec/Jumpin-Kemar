using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class die : MonoBehaviour
{
    public Mouvment playerPosition;
    public GameObject player;
    private Vector3 spawn;
    public GameObject gameover;
    void Start()
    {
        playerPosition = FindObjectOfType<Mouvment>();
        spawn = playerPosition.spawn;

    }
    private IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            Timer timerObject = FindObjectOfType<Timer>();
            timerObject.reset();
            gameover.SetActive(true);
            player.transform.position = spawn;
            yield return new WaitForSeconds(2);
            gameover.SetActive(false);

        }
    }
}
