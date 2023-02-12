using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine _stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this._stateMachine = stateMachine;
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        _stateMachine._controller.Move((motion + _stateMachine._forceReceiver._movement) * deltaTime);
    }

    protected void FacePlayer()
    {
        if (_stateMachine._player == null)
        {
            return;
        }

        Vector3 lookPos = _stateMachine._player.transform.position - _stateMachine.transform.position;
        lookPos.y = 0f;
        _stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }

    protected bool IsInChaseRange()
    {
        float playerDistanceSqr = (_stateMachine._player.transform.position - _stateMachine.transform.position).sqrMagnitude;

        return playerDistanceSqr <= _stateMachine._playerChasingRange * _stateMachine._playerChasingRange;
    }


}
