using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachineOwner
{
}

/// <summary>
/// 角色状态机
/// </summary>
public class StateMachine
{
    private StateBase currentState;         //当前角色状态
    private IStateMachineOwner owner;       //状态机宿主
    private Dictionary<Type, StateBase> stateDic = new Dictionary<Type, StateBase>();
    
    public StateMachine(IStateMachineOwner owner)
    {
        this.owner = owner;
    }

    public void AddState<T>(T state) where T : StateBase
    {
        stateDic.Add(state.GetType(), state);
    }

    public void ChangeState<T>() where T : StateBase
    {
        if (currentState is T)
        {
            return;
        }
        
        currentState?.Exit();
        currentState=stateDic[typeof(T)];
        currentState.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
}
