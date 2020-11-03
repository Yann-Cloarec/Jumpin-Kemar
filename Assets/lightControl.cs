using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControl : MonoBehaviour
{
    public Light torchLight;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.F))
        {
            torchLight.GetComponent<Light>().enabled = !torchLight.GetComponent<Light>().enabled;
        }

    }
}
