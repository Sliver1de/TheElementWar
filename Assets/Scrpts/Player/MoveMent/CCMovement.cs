using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(CharacterController))]
public class CCMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float mouseSensitivity = 100f;
    
    private CharacterController controller;

    private float rotateX;

    private float verticalVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        Rotation();
    }

    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        if (controller.isGrounded)
        {
            verticalVelocity = -2f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            }
        }
        
        Vector3 moveDir = transform.right * horizontal + transform.forward * vertical;
        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        moveDir.y = verticalVelocity;
        
        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }

    public void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseX * mouseSensitivity, 0);

        rotateX -= mouseY * mouseSensitivity;
        rotateX = Mathf.Clamp(rotateX, -90f, 90f);
        
        Camera.main.transform.localRotation = Quaternion.Euler(rotateX, 0, 0);
    }
}
