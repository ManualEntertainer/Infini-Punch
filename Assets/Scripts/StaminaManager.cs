using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public float stamina = 1f;
    private float staminaIncreaseOvertime = 0.1f;
    public Slider staminaSlider;

    public TextMeshProUGUI winTextP1;
    public TextMeshProUGUI winTextP2;

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
                /*if (gameObject.name == "Glass Joe (P2)")
                {
                    winTextP2.enabled = true;
                }
                else
                {
                    winTextP1.enabled = true;
                }*/
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
