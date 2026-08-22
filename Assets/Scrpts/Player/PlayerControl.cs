using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IStateMachineOwner
{
    [SerializeField] private Weapon weapon;

    [SerializeField] private StateMachine _stateMachine;
    
    public Vector2 MoveInput { get; private set; }
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _stateMachine = new StateMachine(this);
        _stateMachine.AddState(new PlayerIdleState());
        _stateMachine.AddState(new PlayerMoveState());
        
        _stateMachine.ChangeState<PlayerIdleState>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
        
        ReadInput();
        
        _stateMachine.Update();
    }

    private void ReadInput()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
