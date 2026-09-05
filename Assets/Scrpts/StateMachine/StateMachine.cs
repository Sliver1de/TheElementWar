using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色状态机
/// </summary>
public class StateMachine
{
    #region abstract 实现

    /*private StateBase currentState;         //当前角色状态
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
    }*/

    #endregion
    
    public IState CurrentState { get; private set; }

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(IState newState)
    {
        if (newState == null || newState == CurrentState) return;
        
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState?.Execute();
    }
}
