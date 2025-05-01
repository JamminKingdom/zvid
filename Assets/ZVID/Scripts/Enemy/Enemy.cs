using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MonoBehaviour _currentState;
    
    public MonoBehaviour idleState;
    public MonoBehaviour chaseState;
    public MonoBehaviour attackState;
    public MonoBehaviour hitState;
    public MonoBehaviour deadState;
    
    public EnemyData _data;

    private void Awake()
    {
        idleState = GetComponent<EnemyIdle>();
        chaseState = GetComponent<EnemyChase>();
        // attackState = GetComponent<EnemyAttack>();
        hitState = GetComponent<EnemyHit>();
        deadState = GetComponent<EnemyDead>();
        
        idleState.enabled   = false;
        chaseState.enabled  = false;
        attackState.enabled = false;
        hitState.enabled    = false;
        deadState.enabled   = false;
        
        _data = GetComponent<EnemyData>();
    }
    
    private void Start()
    {
        SetState(idleState);
    }
    
    public void SetState(MonoBehaviour newState)
    {
        if (newState != _currentState && _currentState != null)
        {
            _currentState.enabled = false;
        }
        
        _currentState = newState;
        _currentState.enabled = true;
    }
    
    public void TakeDamage(int damage)
    {
        _data.Hp -= damage;
        
        if (_data.Hp <= 0)
        {
            SetState(deadState);
        }
        else
        {
            SetState(hitState);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player.Instance.stebba.TakeDamage(_data.attackDamage);
        }
    }
}
