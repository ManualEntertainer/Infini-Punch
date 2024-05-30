using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject hitbox;
    PlayerController controls;

    Animator animator;

    void Awake()
    {
        controls = new PlayerController();
        animator = GetComponent<Animator>();

        //controls.Gameplay.Punch.performed += ctx => Punch();
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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Punch();
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

    public void HitboxOn()
    {
        hitbox.SetActive(true);
    }

    public void HitboxOff()
    {
        hitbox.SetActive(false);
    }
}
