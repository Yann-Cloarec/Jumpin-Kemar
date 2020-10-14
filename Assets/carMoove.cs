using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class carMoove : MonoBehaviour {
     
    float yspeep = 0f;
    float friction = 0.95f;
    bool forward = false;
    bool backward = false;
    bool isGrounded;
    float x_start_position = 0f;
    float y_start_position = 0f;
    float z_start_position = 0f;
    public float fuel = 2;
    public float power = 1f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject car;
    
    void Start(){
        x_start_position = car.transform.position.x;
        y_start_position = car.transform.position.y;
        z_start_position = car.transform.position.z;
    }
    void FixedUpdate () {
         
         
        if(forward){
            yspeep += power;
            fuel -= power;
        }
        if(backward){
            yspeep -= power;
            fuel -= power;
        }
        
         
    }
     
    void Update () {
        forward = true;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(fuel < 0){
            forward = false;
            yspeep = 0;
        }
        
        yspeep *= friction;
        transform.Translate(Vector3.forward * -yspeep);
        Debug.Log("IsGrounded car  : "+ isGrounded);
        if(!isGrounded){
            fuel = 100;
            car.SetActive(false);
            car.transform.position = new Vector3(x_start_position, y_start_position, z_start_position);
            car.SetActive(true);

        }
    }
 }