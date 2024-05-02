using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    GameObject ftobj;
    //private forcetest ft;
    
    public bool fttrue;
    public float ftpower;
    
    [Header("Movement")]
    public float moveSpeed;
    public Camera mainCamera;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        ftobj = GameObject.Find("forceitem");
        rb = GetComponent<Rigidbody>();
        //ft = GetComponent<forcetest>();
        rb.freezeRotation = true;

        readyToJump = true;
        
    }

    private void Update()
    {
        ftpower = ftobj.GetComponent<forceeee>().sensorValue1;
        

        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();
        
        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void LateUpdate()
    {
        // when to jump (arduino)
        if (ftpower > 1 && readyToJump && grounded )
        {
            
            readyToJump = false;
            ftJump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        


        // when to jump (keyboard)
        if (Input.GetKey(jumpKey) && readyToJump )
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
       // if (grounded)
           // rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
       if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void ftJump()
    {
        if (!grounded && !readyToJump)
        {
            return;
        }
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraUp = mainCamera.transform.up;

        Vector3 jumpDirection = (cameraForward + cameraUp).normalized;

        rb.velocity = jumpDirection * jumpForce * ftpower/100;
    }
    private void Jump()
    {
        if (!grounded&&!readyToJump)
        {
            return;
        }
        Vector3 cameraForward = mainCamera.transform.forward; 
        Vector3 cameraUp = mainCamera.transform.up; 

        Vector3 jumpDirection = (cameraForward + cameraUp).normalized; 

        rb.velocity = jumpDirection * jumpForce; 
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
    private void Resetftpower()
    {
        ftpower=0;
    }
}
