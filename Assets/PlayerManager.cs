using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script to handle input, animations, mechanics of the player
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject hitbox;
    PlayerController controls;

    StaminaManager staminaManager;

    Animator animator;



    void Awake()
    {
        controls = new PlayerController();
        animator = GetComponent<Animator>();
        staminaManager = GetComponent<StaminaManager>();

        //controls.Gameplay.Punch.performed += ctx => Punch(); Doesnt work, watch video again.
    }

    // Start is called before the first frame update
    void Start()
    {
        hitbox.SetActive(false);
        EnableHitbox enableHitbox = GetComponent<EnableHitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && staminaManager.staminaSlider.value >= 0.3)
        {
            Punch();
            staminaManager.ReduceStamina(0.3f);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            Block();
        }
    }

    //ABSTRACTION
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

    public void HitboxOn()
    {
        hitbox.SetActive(true);
    }

    public void HitboxOff()
    {
        hitbox.SetActive(false);
    }
}
