
using UnityEngine;

public class MooveLaterally : MonoBehaviour
{

    public float speed = 2f;
    public float maxRange = 10f;
    public bool right = true;
    public float power = 0.1f;
    float start_x = 0f;
    private void Start()
    {
        start_x = transform.position.x;
    }
    void Update()
    {
        if(right)
        {
            if(transform.position.x < start_x + maxRange)
            {
                GetComponent<Rigidbody>().velocity = Vector3.right * speed;
                
            } else
            {
                right = false;
            }


        } else
        {
            if (transform.position.x > start_x - maxRange)
            {
                GetComponent<Rigidbody>().velocity = Vector3.left * speed;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            }
            else
            {
                right = true;
            }
        }


    }
}