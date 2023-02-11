using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _animator;
    // [SerializeField] Player _playerHp;

    [Header("Stats")]
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _chaseSpeed;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _damageDealt;
    [SerializeField] private float _rotationSpeed;

    [Header("Wandering parameters")]
    [SerializeField] private float _wanderingWaitTimeMin;
    [SerializeField] private float _wanderingWaitTimeMax;
    [SerializeField] private float _wanderingDistanceMin;
    [SerializeField] private float _wanderingDistanceMax;

    #region Privates
    private bool _hasDestination;
    private bool _isAttacking;
    #endregion

    #region Life cycle
    private void Awake()
    {
        gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
    }
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(_player.position, transform.position) < _detectionRadius)
        {
            _agent.speed = _chaseSpeed;

            Quaternion rot = Quaternion.LookRotation(_player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, _rotationSpeed * Time.deltaTime);  
            if (!_isAttacking)
            {
                if (Vector3.Distance(_player.position, transform.position) < _attackRadius)
                {
                    StartCoroutine(AttackPlayer());
                }
                else
                {
                    _agent.SetDestination(_player.position);
                }
            }

        }
        else
        {
            _agent.speed = _walkSpeed;
            if (_agent.remainingDistance < 0.75f && !_hasDestination)
            {
                StartCoroutine(GetNewDestination());
            }
        }
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }


    #endregion


    IEnumerator GetNewDestination()
    {
        _hasDestination = true;
        yield return new WaitForSeconds(Random.Range(_wanderingWaitTimeMin, _wanderingWaitTimeMax));

        Vector3 nextDestination = transform.position;
        nextDestination += Random.Range(_wanderingDistanceMin, _wanderingDistanceMax) * new Vector3(Random.Range(-1, 1), 0f, Random.Range(-1, 1)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(nextDestination, out hit, _wanderingDistanceMax, NavMesh.AllAreas))
        {
            _agent.SetDestination(hit.position);
        }
        _hasDestination = false;
    }

    IEnumerator AttackPlayer()
    {
        _isAttacking = true;
        _agent.isStopped = true;

        _animator.SetTrigger("Attack");
        // _playerHp.TakeDamage(_damageDealt);

        yield return new WaitForSeconds(_attackDelay);
        _agent.isStopped = false;
        _isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }


}
