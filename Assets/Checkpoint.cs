using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Mouvment player;
    private Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("Spawn").transform.position;
        player = FindObjectOfType<Mouvment>();
        player.SetSpawn(spawn);
        player.SetCheckpoint(spawn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))  
        {
            player.SetCheckpoint(transform.position);
        }
    }
}
