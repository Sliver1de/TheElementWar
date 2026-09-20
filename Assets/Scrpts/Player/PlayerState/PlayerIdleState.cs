using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    public void Enter()
    {
        Debug.Log("Enter");
    }

    public void Execute()
    {
        Debug.Log("Execute");
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }
}
