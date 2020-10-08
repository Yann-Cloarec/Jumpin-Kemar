using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedLabel : MonoBehaviour
{
    public Text mySpeedLabel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSpeedLabel(string speed){
        mySpeedLabel.text = speed + " km/h";
    }   
}
