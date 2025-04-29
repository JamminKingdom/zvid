using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    
    private NavMeshAgent _agent;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Start()
    {
        UpdateDestination();
    }

    private void Update()
    {
        UpdateDestination();
    }

    private void UpdateDestination()
    {
        _agent.SetDestination(Player.Instance.transform.position);
    }

    private void OnEnable()
    {
        _agent.isStopped = false;
        _agent.ResetPath();
    }
    
    private void OnDisable()
    {
        _agent.isStopped = true;
        _agent.ResetPath();
    }
}