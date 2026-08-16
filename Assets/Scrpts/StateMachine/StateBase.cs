using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态基类
/// </summary>
public abstract class StateBase
{
    protected IStateMachineOwner owner;

    public virtual void Init(IStateMachineOwner owner)
    {
        this.owner = owner;
    }
    
    public virtual void Enter() { }
    
    public virtual void Exit() { }

    public virtual void Update() { }
    
    public virtual void Destroy() { }

}
