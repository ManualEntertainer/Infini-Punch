using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        stamina = staminaSlider.value;

        if (stamina < 0.333f)
        {
            if (!animator.GetBool("hasLowStamina"))
            {
                animator.SetBool("hasLowStamina", true);
            }
        }
        else
        {
            if (animator.GetBool("hasLowStamina"))
            {
                animator.SetBool("hasLowStamina", false);
            }
        }
    }
}
