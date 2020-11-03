using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swan : MonoBehaviour
{
    public AudioSource prout;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            prout.GetComponent<AudioSource>().Play();
        }

    }
}
