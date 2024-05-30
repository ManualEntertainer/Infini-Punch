using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHitbox : MonoBehaviour
{
    [SerializeField] private BoxCollider2D hitbox;
    // Start is called before the first frame update
    void Start()
    {
        hitbox.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitboxOn()
    {
        hitbox.enabled = true;
    }

    public void HitboxOff()
    {
        hitbox.enabled = false;
    }
}
