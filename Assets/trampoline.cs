using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    public Mouvment mouvment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            CharacterController controller = other.GetComponent<CharacterController>();
            mouvment.velocity.y = Mathf.Sqrt(mouvment.jumpHeight * mouvment.constJump * mouvment.gravity);
            controller.Move(mouvment.velocity * Time.deltaTime);
        }        
    }
}
