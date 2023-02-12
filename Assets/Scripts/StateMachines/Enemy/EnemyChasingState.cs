using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    private readonly int _locomotionHash = Animator.StringToHash("Locomotion");
    private readonly int _speedHash = Animator.StringToHash("Speed");

    private const float _crossFadeDuration = 0.1f;
    private const float _animatorDampTime = 0.1f;
    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        _stateMachine._animator.CrossFadeInFixedTime(_locomotionHash, _crossFadeDuration);
    }


    public override void Tick(float deltaTime)
    {

        if (!IsInChaseRange())
        {
            _stateMachine.SwitchState(new EnemyIdleState(_stateMachine));

            return;
        } else if (IsAttackRange())
        {
            _stateMachine.SwitchState(new EnemyAttackingState(_stateMachine));
            return;
        }

        MoveToPlayer(deltaTime);

        FacePlayer();

        _stateMachine._animator.SetFloat(_speedHash, 1f, _animatorDampTime, deltaTime);
    }

    public override void Exit()
    {
        _stateMachine._agent.ResetPath();
        _stateMachine._agent.velocity = Vector3.zero;
    }

    private void MoveToPlayer(float deltaTime)
    {
        _stateMachine._agent.destination = _stateMachine._player.transform.position;

        Move(_stateMachine._agent.desiredVelocity.normalized * _stateMachine._movementSpeed, deltaTime);

        _stateMachine._agent.velocity = _stateMachine._controller.velocity;
    }

    private bool IsAttackRange()
    {
        float playerDistanceSqr = (_stateMachine._player.transform.position - _stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= _stateMachine._attackRange * _stateMachine._attackRange;
    }
}
