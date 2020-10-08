using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class staminaBar : MonoBehaviour
{
    public Slider staminaSlider;
    public stamina playerStamina;

    private void Start()
    {
        playerStamina = GameObject.FindGameObjectWithTag("Player").GetComponent<stamina>();
        staminaSlider = GetComponent<Slider>();
    }

    public void setStamina(float stamina)
    {
        staminaSlider.value = stamina;
    }
}
