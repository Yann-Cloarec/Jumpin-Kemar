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
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            
            gameover.SetActive(true);
            yield return new WaitForSeconds(3);
            gameover.SetActive(false);
            player.transform.position = new Vector3(0,0,0);

        }
    }
}
