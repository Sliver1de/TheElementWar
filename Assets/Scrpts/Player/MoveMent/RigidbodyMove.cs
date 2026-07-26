using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    
    public float mouseSensitivity = 100f;
    
    //地面检测
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    //相机根节点
    public Transform cameraRoot;

    private Rigidbody rb;
    
    //俯仰角
    private float pitch;

    private float horizontal;
    private float vertical;

    private bool isGrounded;

    private bool hasJumped;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        Physics.gravity = new Vector3(0, -25f, 0);
    }


    private void Update()
    {
        HandleInput();
        HandleLock();
        HandleJump();
    }

    private void FixedUpdate()
    {
        HandleMove();
    }

    private void HandleInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void HandleLock()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);
        
        pitch -= mouseY * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        
        cameraRoot.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

    public void HandleJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // if (isGrounded)
        // {
        //     hasJumped = false;
        // }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            
            Vector3 v = rb.velocity;
            v.y = 0;
            rb.velocity = v;
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void HandleMove()
    {
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        
        moveDirection = moveDirection.normalized * moveSpeed;

        Vector3 velocity = rb.velocity;
        
        // velocity.x = rb.velocity.x;      //已冻结
        // velocity.z = rb.velocity.z;
        // // Debug.Log(velocity.y);
        
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
        {
            return;
        }

        Gizmos.color = Color.green;
        
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
