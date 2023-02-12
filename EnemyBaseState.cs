using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyBaseState _stateMachine;

    public EnemyBaseState(EnemyBaseState stateMachine)
    {
        this._stateMachine = stateMachine;
    }
}
