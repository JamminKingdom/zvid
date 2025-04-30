using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyIdle : EnemyStateBase
{
    [Header("Wander Settings")]
    [SerializeField] private float wanderRadius   = 5f;
    [SerializeField] private float wanderInterval = 7f;

    private NavMeshAgent _agent;
    private Coroutine    _wanderRoutine;

    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis   = false;
    }

    private void OnEnable()
    {
        Wander();
    }

    private void OnDisable()
    {
        if (_wanderRoutine != null)
            StopCoroutine(_wanderRoutine);
        _agent.ResetPath();
    }

    private void Wander()
    {
        StartCoroutine(WanderRoutine());
    }

    private IEnumerator WanderRoutine()
    {
        while (true)
        {
            int pattern = Random.Range(1, 3);
            
            if (pattern == 1)
            {
                Vector2 randCircle = Random.insideUnitCircle * wanderRadius;
                Vector3 dest = transform.position + (Vector3)randCircle;

                if (_agent.isOnNavMesh &&
                    NavMesh.SamplePosition(dest, out var hit, 1f, NavMesh.AllAreas))
                {
                    _agent.SetDestination(hit.position);
                }
            }

            yield return new WaitForSeconds(wanderInterval);
        }
    }

    private void Update()
    {
        bool isMoving = _agent.velocity.sqrMagnitude > 0.01f;
        anim.SetBool(data.HashIsWalking, isMoving);

        if (data.isWalking)
        {
            enemy.SetState(enemy.chaseState);
        }
    }
}
