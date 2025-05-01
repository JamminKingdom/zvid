using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharge : EnemyStateBase
{
    [Header("Charge Settings")]
    [SerializeField] private float chargeDelay    = 1f;
    [SerializeField] private float chargeSpeed    = 8f;
    [SerializeField] private float chargeDuration = 2f;

    private NavMeshAgent _agent;
    private float         _originalSpeed;
    
    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis   = false;
        _originalSpeed        = _agent.speed;
    }

    private void OnEnable()
    {
        if (!_agent.enabled && _agent.isOnNavMesh)
        {
            _agent.isStopped = true;
            _agent.ResetPath();
        }

        anim.SetBool(data.HashIsWalking, false);

        StartCoroutine(ChargeProcess());
    }

    private void OnDisable()
    {
        if (!_agent.enabled && _agent.isOnNavMesh)
            _agent.speed = _originalSpeed;
        
        if (!_agent.enabled && _agent.isOnNavMesh)
            _agent.isStopped = false;
    }

    private IEnumerator ChargeProcess()
    {
        anim.SetTrigger(data.HashAttack);  
        yield return new WaitForSeconds(chargeDelay);

        if (!_agent.enabled)
            yield break;

        _agent.speed = chargeSpeed;
        _agent.isStopped = false;
        Vector3 targetPos = Player.Instance.transform.position;
        _agent.SetDestination(targetPos);

        float t = 0f;
        while (t < chargeDuration)
        {
            t += Time.deltaTime;
            yield return null;
        }

        enemy.SetState(enemy.chaseState);
    }
}