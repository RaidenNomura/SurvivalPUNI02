using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float _time = 5;


    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        _time -= deltaTime;
        Debug.Log(_time);
        if (_time <= 0 )
        {
            _stateMachine.SwitchState(new PlayerTestState(_stateMachine));
        }


    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }
}
