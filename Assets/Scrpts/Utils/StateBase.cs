using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态基类
/// </summary>
public abstract class StateBase
{
    public virtual void Enter() { }
    
    public virtual void Exit() { }

    public virtual void Init(IStateMachineOwner owner) { }

    public virtual void Destroy() { }

    public virtual void Update() { }

}
