using UnityEngine.AI;

public class EnemyChase : EnemyStateBase
{
    public float moveSpeed = 0.1f;
    
    private NavMeshAgent _agent;
    
    protected override void Awake()
    {
        base.Awake();
        
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }
      
    private void OnEnable()
    {
        anim.SetBool(data.HashIsWalking, data.isWalking);
        _agent.isStopped = false;
        
        if (_agent.isOnNavMesh)
            _agent.ResetPath();
    }
    
    
    private void Update()
    {
        UpdateDestination();
        
        if (data.dirVec.sqrMagnitude < data.attackRangeSqr)
        {
            enemy.SetState(enemy.attackState);
        }
        else if (data.dirVec.sqrMagnitude > data.detectionRangeSqr)
        {
            enemy.SetState(enemy.idleState);
        }
    }
    
    private void OnDisable()
    {
        _agent.isStopped = true;
        
        if (_agent.isOnNavMesh)
            _agent.ResetPath();
    }

    private void UpdateDestination()
    {
        _agent.SetDestination(Player.Instance.transform.position);
        spriteRenderer.flipX = data.dirVec.x < 0f;
    }
}
