using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public Animator _animator { get; private set; }

    [field: SerializeField] public CharacterController _controller { get; private set; }

    [field: SerializeField] public ForceReceiver _forceReceiver { get; private set; }

    [field: SerializeField] public NavMeshAgent _agent { get; private set; }
    [field: SerializeField] public float _movementSpeed { get; private set; }
    [field: SerializeField] public float _playerChasingRange { get; private set; }

    [field: SerializeField] public float _attackRange { get; private set; }

    public GameObject _player { get; private set; }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _agent.updatePosition = false;
        _agent.updateRotation = false;

        SwitchState(new EnemyIdleState(this));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _playerChasingRange);
    }
}
