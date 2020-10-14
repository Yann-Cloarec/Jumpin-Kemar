using UnityEngine;
using System.Collections;
 
public class cameraMouvment : MonoBehaviour {
public Transform target;
public float moveSpeed = 10.0f;
public float rotateSpeed = 90.0f;
private Transform myTransform;
    void Start() {
        transform.position = target.position;
        transform.rotation = target.rotation;
        myTransform = transform;
    }
    void Update() {
        myTransform.position = Vector3.MoveTowards(myTransform.position, new Vector3(target.position.x,target.position.y,target.position.z), moveSpeed * Time.deltaTime);
        myTransform.rotation = Quaternion.RotateTowards(myTransform.rotation, target.rotation, rotateSpeed * Time.deltaTime);
    }
 
}