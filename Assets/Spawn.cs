using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public Mouvment player;
    private Vector3 spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("Spawn").transform.position;
        player = FindObjectOfType<Mouvment>();
        player.SetSpawn(spawn);
    }
}
