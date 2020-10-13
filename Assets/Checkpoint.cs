using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Mouvment player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Mouvment>();
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
