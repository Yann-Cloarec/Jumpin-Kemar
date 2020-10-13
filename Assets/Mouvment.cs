﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvment : MonoBehaviour
{
    // We need to synchronize speed and FOV
    float speed;
    public const float minSpeed = 5f;
    public const float maxSpeed = 15f;
    public const float acceleration = 0.03f;
    public const float minFieldOfView=70f;
    public const float maxFieldOfView=100f;
    public const float fovAcceleration = 0.03f;
    public const float constVelocity = -2f;
    public  float constJump = -2f;
    public const float zero = 0;
    public const float staminaCost = 0.1f;
    public const float breakSpeed = 4f;
    public stamina playerStamina;
    public speedLabel speedLabel;
    public CharacterController controller;
    public Animator myAnimator;
    public float gravity = -15f;
    public float jumpHeight = 5f;
    public float trampoJumpHeight;
    public Vector3 checkpoint;
    public Vector3 spawn;

    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask trampoMask;
    public Vector3 velocity;
    bool isGrounded;
    bool isTrampoline;
    bool candoublejump;
    public float highestHeightBeforeGround=0f;
    private void Start() {
        speed = minSpeed;
        Camera.main.fieldOfView = minFieldOfView;
        playerStamina = GameObject.FindGameObjectWithTag("Player").GetComponent<stamina>();
    }
    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y > highestHeightBeforeGround){
            highestHeightBeforeGround = this.transform.position.y ;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        isTrampoline = Physics.CheckSphere(groundCheck.position, groundDistance, trampoMask);
        if(isGrounded){
            myAnimator.SetBool("isMidAir",false);
            highestHeightBeforeGround = 0f ;

            if(velocity.y < zero){
                velocity.y = constVelocity;
            }
            // Sprint gestion
            if(Input.GetButton("Fire3") && Input.GetAxis("Vertical") > zero && !playerStamina.repos){
                myAnimator.SetBool("isSprint",true);
                speed += speed < maxSpeed ? acceleration : zero;
                Camera.main.fieldOfView += Camera.main.fieldOfView < maxFieldOfView ? fovAcceleration:zero;
                playerStamina.modifStamina(-staminaCost);
            }else{
                myAnimator.SetBool("isSprint",false);
                speed -= speed > minSpeed ? acceleration : zero;
                Camera.main.fieldOfView -= Camera.main.fieldOfView > minFieldOfView ? fovAcceleration:zero;
                playerStamina.modifStamina(staminaCost);
            }
            if(Input.GetKey("s")){
                myAnimator.SetBool("isSprint",false);
                speed -= speed > minSpeed ? acceleration * breakSpeed : zero;
                Camera.main.fieldOfView -= Camera.main.fieldOfView > minFieldOfView ? fovAcceleration * breakSpeed :zero;
            }
        }else{
            myAnimator.SetBool("isMidAir",true);
        }        

        // Set ui
        speedLabel.setSpeedLabel(Mathf.Round(speed).ToString());
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if ( x != 0 || z > 0 ) {
            myAnimator.SetBool("isRunning",true);
            myAnimator.SetBool("isBackwardRunning",false);
        }else if( z < 0){
            myAnimator.SetBool("isRunning",false);
            myAnimator.SetBool("isBackwardRunning",true);
        }else{
            myAnimator.SetBool("isRunning",false);
            myAnimator.SetBool("isBackwardRunning",false);
        }
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump")) {
            if (isGrounded) {
                velocity.y = Mathf.Sqrt(jumpHeight * constJump * gravity);
                candoublejump = true;
            } else {
                if (candoublejump) {
                candoublejump = false;
                velocity.y = Mathf.Sqrt(jumpHeight * constJump * gravity);
                }
            }
         }
        if(Input.GetKey(KeyCode.F1)){
            myAnimator.SetBool("isDancing",true);
        }else{
            myAnimator.SetBool("isDancing",false);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Respawn the user to the latest checkpoint
        if (Input.GetKey(KeyCode.E))
        {
            RespawnCheckPoint();
        }

        if (Input.GetKey(KeyCode.R))
        {
            Respawn();
        }
    }

    private void RespawnCheckPoint()
    {
        controller.transform.position = checkpoint;
    }

    private void Respawn()
    {
        controller.transform.position = spawn;
    }

    public void SetSpawn(Vector3 newSpawn)
    {
        spawn = newSpawn;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpoint = newCheckpoint;
    }
}