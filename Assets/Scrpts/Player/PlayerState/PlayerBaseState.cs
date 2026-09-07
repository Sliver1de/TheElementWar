using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerControl player;

    public PlayerBaseState(PlayerControl player)
    {
        this.player = player;
    }


    public virtual void Enter()
    {
    }

    public void Execute()
    {
        //Player通用逻辑处理
    }

    public void Exit()
    {
    }
}
