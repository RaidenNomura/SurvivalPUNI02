using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int _attackHash = Animator.StringToHash("Attack");

    private const float _transitionDuration = 0.1f;
    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("je suis dans attack");
        _stateMachine._animator.CrossFadeInFixedTime(_attackHash, _transitionDuration);
    }


    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {
    }


}
