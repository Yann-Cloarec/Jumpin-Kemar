using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blackFlash : MonoBehaviour
{
    public Image blackImage;
    public const float flashDelay = 0.2f;
    public const float nbFlash = 2f;
    // Start is called before the first frame update
    void Start()
    {
        blackImage.color=new Color(255,255,255,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void flash(){
        StartCoroutine(flashCoroutine());
    }
    IEnumerator  flashCoroutine(){
        for (int i = 0; i < nbFlash; i++)
        {
            blackImage.color=new Color(255,255,255,0.2f);
            yield return new WaitForSeconds(flashDelay); 
            blackImage.color=new Color(255,255,255,0);
            yield return new WaitForSeconds(flashDelay); 
        }
    }
}
