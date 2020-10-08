using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stamina : MonoBehaviour
{
    public float curStamina = 0f;
    public const float maxStamina = 100f;
    public const float minStamina = 0f;

    public bool repos = false;
    public staminaBar staminaBar;
    public blackFlash blackFlash;

    // Start is called before the first frame update
    void Start()
    {
        curStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void modifStamina (float stamina){
        float tempStamina=curStamina+stamina;
        if((tempStamina >= minStamina) && (tempStamina <= maxStamina)){
            curStamina=tempStamina;
        staminaBar.setStamina(curStamina);
        }else if(tempStamina < minStamina){
            blackFlash.flash();
            repos=true;
        }else if(tempStamina > maxStamina){
            repos=false;
        }
    }

}
