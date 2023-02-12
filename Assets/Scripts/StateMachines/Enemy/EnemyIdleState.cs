using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private readonly int _locomotionHash = Animator.StringToHash("Locomotion");
    private readonly int _speedHash = Animator.StringToHash("Speed");

    private const float _crossFadeDuration = 0.1f;
    private const float _animatorDampTime = 0.1f;
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        _stateMachine._animator.CrossFadeInFixedTime(_locomotionHash, _crossFadeDuration);
    }


    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        if (IsInChaseRange())
        {
            _stateMachine.SwitchState(new EnemyChasingState(_stateMachine));

            return;
        }

        FacePlayer();

        _stateMachine._animator.SetFloat(_speedHash, 0f, _animatorDampTime, deltaTime);
    }

    public override void Exit()
    {
    }
}
