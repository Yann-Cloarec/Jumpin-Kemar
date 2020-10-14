using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;


public class wallRun : MonoBehaviour
{
    public Transform FPSCam;
 
     public float WallRunTurnAmount = 10f;
 
     public float JumpOffUpwardsPush = 100f;
     public float JumpOffUpwardsPushMultiplier = 1000f;
     public CharacterController controller;
     public Mouvment mouvment;
 
     void Start()
     {
     }

    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask =  LayerMask.GetMask("Immeuble");

        var lft = transform.TransformDirection(Vector3.left);
        var rgt = transform.TransformDirection(Vector3.right);
        var raycastLeft = Physics.Raycast(transform.position, lft, 1.8F);
        var raycastRight = Physics.Raycast(transform.position, rgt, 1.8F);

//         RaycastHit.collider doesn’t equal null? That might be a wall…
//         RaycastHit.normal dot Vector3.Up equals 0? If yes, the two vectors are orthagonal which means the wall candidate is perpendicular to the ground. That’s a runnable wall!
//         If both raycasts hit wall runnable walls, discard the one further away and keep the closest
//         If we have a runnable wall, enter wall running state (otherwise, exit here and wait until next frame)
//         RaycastHit.normal X Vector3.Up (cross product) gives us the orthagonal vector - which is the vector along the wall
//         Tell our character to move along this vector. Do something with vertical velocity (like ignore or limit it)
        if(raycastLeft || raycastRight)
        {
            mouvment.gravity = 0F;
            var direction = rgt;
            if (raycastLeft) {
                direction = lft;
            }
            // UnityEngine.Debug.Log("Did Hit");
        }
        else
        {
            mouvment.gravity = -15F;
            // UnityEngine.Debug.Log("Did Not Hit");
        }
    }
}