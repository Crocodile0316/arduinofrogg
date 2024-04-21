using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    //AudioManager audioManager;
    Animator playerAnim;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public float animacooldown;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }
    void jumpanimation()
    {
        print("jump");
        playerAnim.SetBool("jumping", true);
        //Invoke(nameof(stopjump), animacooldown);
    }
    void stopjump()
    {
        //print("stopjump");
        playerAnim.SetBool("jumping", false);
        playerAnim.SetBool("1Frogstanding", true);
    }
        void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        //
        if (!grounded)
        {
            print("Jump");
            jumpanimation();
            Invoke(nameof(stopjump), animacooldown);
        }

        if (grounded)
        {
            //print("Stop Jump");
            playerAnim.SetBool("jumping", false);
        }

    }
}
