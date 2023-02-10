using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform _player;

    [Header("Stats")]
    [SerializeField] float _detectionRadius;

    [Header("Wandering parameters")]
    [SerializeField] private float _wanderingWaitTimeMin;
    [SerializeField] private float _wanderingWaitTimeMax;
    [SerializeField] private float _wanderingDistanceMin;
    [SerializeField] private float _wanderingDistanceMax;
    private bool _hasDestination;

    #region Life cycle
    private void Awake()
    {
    }
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(_player.position, transform.position) < _detectionRadius)
        {
            _agent.SetDestination(_player.position);
        }
        else
        {
            if (_agent.remainingDistance < 0.75f && !_hasDestination)
            {
                StartCoroutine(GetNewDestination());
            }
        }

    }
    private void FixedUpdate()
    {

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }


}
