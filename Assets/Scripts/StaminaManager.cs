using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    protected float stamina = 1f;
    private float staminaIncreaseOvertime = 0.1f;
    public Slider staminaSlider;

    public bool isBlocking = false;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        staminaSlider.value = stamina;
        if (stamina < 1 && !isBlocking)
        {
            stamina += staminaIncreaseOvertime * Time.deltaTime;
            if (stamina <= 0)
            {
                stamina = 0;
                Destroy(gameObject);
            }

        }
        else if (stamina > 1) 
        {
            stamina = 1;
        }
    }

    public void ReduceStamina(float reduceAmount)
    {
        stamina -= reduceAmount;
    }
    public void GainStamina(float gainAmount)
    {
        stamina += gainAmount;
    }


}
