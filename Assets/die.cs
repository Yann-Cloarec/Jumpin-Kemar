using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class die : MonoBehaviour
{
    public Mouvment player;
    private Vector3 spawn;
    public GameObject gameover;
    void Start()
    {
        player = FindObjectOfType<Mouvment>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            gameover.SetActive(true);
            player.Respawn();
        }
    }
}
