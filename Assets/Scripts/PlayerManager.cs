using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script to handle input, animations, mechanics of the player
public class PlayerManager : MonoBehaviour
{
    public GameObject hitbox;
    PlayerController controls;

    StaminaManager staminaManager;

    Animator animator;

    public float parryDuration = 0.5f; // Duration the parry window is active
    private bool isParrying = false;
    private float parryTimer = 0f;


    void Awake()
    {
        controls = new PlayerController();
        animator = GetComponent<Animator>();
        staminaManager = GetComponent<StaminaManager>();
        hitbox.SetActive(false);

        //controls.Gameplay.Punch.performed += ctx => Punch(); Doesnt work, watch video again.
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //&& staminaManager.staminaSlider.value >= 0.3
        {
            Punch();
            staminaManager.ReduceStamina(0.3f);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartParry();
        }

        // Update parry timer
        if (isParrying)
        {
            parryTimer -= Time.deltaTime;
            if (parryTimer <= 0f)
            {
                EndParry();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Block();
        }
    }

    void Punch()
    {
        animator.SetBool("isPunching", true);
    }

    public void DisablePunch()
    {
        animator.SetBool("isPunching", false);
    }
    void Block()
    {
        animator.SetBool("isBlocking", true);
        staminaManager.isBlocking = true;
    }

    public void DisableBlock()
    {
        animator.SetBool("isBlocking", false);
        staminaManager.isBlocking = false;
    }
    void Parry()
    {
        animator.SetBool("parrySuccess", true);
        staminaManager.GainStamina(0.3f);
    }
    //ABSTRACTION
    public void DisableParry()
    {
        animator.SetBool("parrySuccess", false);
        DisableBlock();
    }

    void StartParry()
    {
        isParrying = true;
        parryTimer = parryDuration;
        Debug.Log("Parry started");
    }

    void EndParry()
    {
        isParrying = false;
        Debug.Log("Parry ended");
    }

    public void HitboxOn()
    {
        hitbox.SetActive(true);
    }

    public void HitboxOff()
    {
        hitbox.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isParrying)
        {
            // Handle successful parry
            Parry();
        }
        else if (!staminaManager.isBlocking)
        {
            // Handle regular hit
            Debug.Log("Collider Detected");
            staminaManager.ReduceStamina(0.25f);
        }

    }
}
