using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// INHERITANCE
public class SkullAnimation : StaminaManager
{
    private Animator animator;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Stamina = staminaSlider.value;

        if (Stamina <= 0f)
        {
            animator.SetBool("isDead", true);
        }
        if (Stamina < 0.333f)
        {
            animator.SetBool("hasLowStamina", true);
        }
        else
        {
            animator.SetBool("hasLowStamina", false);
        }
    }
}
