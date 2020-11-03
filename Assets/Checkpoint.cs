using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{

    public Mouvment player;
    private Vector3 spawn;
    public Text checkpoint;
    public string checkpointName;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("Spawn").transform.position;
        player = FindObjectOfType<Mouvment>();
        player.SetSpawn(spawn);
        player.SetCheckpoint(spawn);
        player.Respawn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))  
        {
            player.SetCheckpoint(transform.position);

            //Update text to save checkpoint's time
            Timer timerObject = FindObjectOfType<Timer>();
            string value = "\n" + checkpointName + " : " + timerObject.getElapsedTime();
            checkpoint.text += value;
            Destroy(this.gameObject);
        }   
    }
}
