using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class Hahahaha : MonoBehaviour
{
    GameObject ftobj;
    public TextMeshPro Forcetext;
    //private forcetest ft;
    public enum SensorType
    {
        SensorValue1,
        SensorValue2,
        SensorValue3,
        SensorValue4
    }
    public SensorType sensorToUse; // Variable to choose which sensor value to use for ftpower

    public bool fttrue;
    public float ftpower;
    public float lastftpower;
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
    public bool clearstage;
    private void Start()
    {
        StartCoroutine(Savepower());
        ftobj = GameObject.Find("forceitem");
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        clearstage = false;
        readyToJump = true;

    }

    private void Update()
    {
        switch (sensorToUse)
        {
            case SensorType.SensorValue1:
                ftpower = ftobj.GetComponent<forceeee>().sensorValue1;
                break;
            case SensorType.SensorValue2:
                ftpower = ftobj.GetComponent<forceeee>().sensorValue2;
                break;
            case SensorType.SensorValue3:
                ftpower = ftobj.GetComponent<forceeee>().sensorValue3;
                break;
            case SensorType.SensorValue4:
                ftpower = ftobj.GetComponent<forceeee>().sensorValue4;
                break;
        }

        if (lastftpower<500)
        {
            lastftpower = 0;
        }
        if (lastftpower >1000)
        {
            lastftpower = 1000;
        }
            forcetext();
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
        if (ftpower == 0 && readyToJump && grounded)
        {


            ftJump();
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
            Resetftpower();


        }
    }

    private IEnumerator Savepower()
    {
        while (true)
        {
            lastftpower = ftpower;

            yield return new WaitForSeconds(0.7f);
        }
    }



    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");



        // when to jump (keyboard)
        if (Input.GetKey(jumpKey) && readyToJump)
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

        rb.velocity = jumpDirection *  lastftpower / 50;
    }
    private void Jump()
    {
        if (!grounded && !readyToJump)
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
        ftpower = 0;
        lastftpower = 0;
    }

    private void forcetext()
    {
        if (lastftpower == 0)
        {
            Forcetext.text = lastftpower.ToString();
        }
        else
        {
            Forcetext.text = ((lastftpower - 500) / 10).ToString("F0");
        }
    }
}