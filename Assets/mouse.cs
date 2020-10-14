using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public float mouseSens = 200f;
    public Transform playerTransform;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        // Permet de faire tourner la caméra
        playerTransform.Rotate(Vector3.up * mouseX);

        xRotation = Mathf.Clamp(xRotation,-90,80);
        xRotation -= mouseY;
        transform.localRotation=Quaternion.Euler(xRotation,0f,0f);
    }
}
