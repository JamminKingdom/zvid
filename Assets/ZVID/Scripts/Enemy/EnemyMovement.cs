using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject shootingPoint;
    [SerializeField]
    private GameObject projectilePrefab;
    
    private Rigidbody2D _rb;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private EnemyData _data;
    private EnemyChase _chase;
    
    private EnemyState _state = EnemyState.Idle;
    
    private readonly int HashIsWalking = Animator.StringToHash("IsWalking");
    private readonly int HashAttack = Animator.StringToHash("Attack");
    private readonly int HashHit = Animator.StringToHash("Hit");
    private readonly int HashDead = Animator.StringToHash("Dead");
    
    public void TakeDamage(int damage)
    {
        if (_state == EnemyState.Hit) return;
        if (_state == EnemyState.Dead) return;

        _data.Hp -= damage;

        if (_data.Hp == 0)
        {
            Dead();
            return;
        }
        
        OnHit(damage);
    }
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _data = GetComponent<EnemyData>();
        _chase = GetComponent<EnemyChase>();
    }

    private void Update()
    {
        if (_state == EnemyState.Hit) return;
        if (_state == EnemyState.Attack) return;
        if (_state == EnemyState.Dead) return;

        _animator.SetBool(HashIsWalking, _data.isWalking);
        
        if (_state == EnemyState.Chase && _data.dirVec.sqrMagnitude < _data.attackRangeSqr)
        {
            Attack();
            return;
        }
        
        if (_data.isWalking)
        {
            _spriteRenderer.flipX = _data.dirVec.x < 0f;
        }
    }

    private void FixedUpdate()
    {
        if (_state == EnemyState.Hit) return;
        if (_state == EnemyState.Attack) return;
        if (_state == EnemyState.Dead) return;
        
        if (_data.dirVec.sqrMagnitude < _data.detectionRangeSqr)
        {
            _state = EnemyState.Chase; 
            _chase.enabled = true;
        }
        else
        {
            _chase.enabled = false;
        }
    }
    
    private void Attack()
    {
        if (_state == EnemyState.Attack) return;
        
        StopAllCoroutines();
        StartCoroutine(AttackProcess());
    }
    
    private IEnumerator AttackProcess()
    {
        _animator.SetTrigger(HashAttack);
        
        FireProjectile();
        
        _chase.enabled = false;
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _state = EnemyState.Attack;
        
        yield return new WaitForSeconds(2f);

        _rb.bodyType = RigidbodyType2D.Dynamic;
        _state = EnemyState.Idle;
    }
    
    private void FireProjectile()
    {
        GameObject projGo = Instantiate(
            projectilePrefab,
            shootingPoint.transform.position,
            shootingPoint.transform.rotation
        );

        EnemyProjectile proj = projGo.GetComponent<EnemyProjectile>();
        if (proj != null)
        {
            int damage = _data.attackDamage;  
            proj.Shot(damage, _data.dirVec);
        }
    }
    
    private void OnHit(int damage = 0)
    {
        StopAllCoroutines();
        StartCoroutine(HitProcess());
    }
    
    private IEnumerator HitProcess()
    {
        _animator.SetTrigger(HashHit);
        
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _state = EnemyState.Hit;
        _chase.enabled = false;
        
        yield return new WaitForSeconds(0.5f);

        _rb.bodyType = RigidbodyType2D.Dynamic;
        _state = EnemyState.Idle;
    }
    
    private void Dead()
    {
        if (_state == EnemyState.Dead) return;
        
        StopAllCoroutines();
        StartCoroutine(DeadProcess());
    }
    
    private IEnumerator DeadProcess()
    {
        _animator.SetTrigger(HashDead);
        
        _chase.enabled = false;
        _rb.simulated = false;
        _collider.enabled = false;
        _state = EnemyState.Dead;
        
        yield return new WaitForSeconds(2f);
        
        SpawnManager.Instance.SpawnRandomItem(transform);
        Destroy(gameObject);
    }
}
