using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    [SerializeField] private StateMachine _stateMachine;
    
    [SerializeField] private CCMovement _ccMovement;
    
    public Vector3 MoveInput { get; private set; }
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
        
        ReadInput();
        
        _ccMovement.Movement(MoveInput);
    }

    private void ReadInput()
    {
        // MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        MoveInput = new Vector3(horizontal, 0f, vertical);
        MoveInput = Vector3.ClampMagnitude(MoveInput, 1f);
    }
}
