using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private EnemyData _data;
    private EnemyChase _chase;
    
    private EnemyState _state = EnemyState.Idle;
    
    private readonly int HashIsWalking = Animator.StringToHash("IsWalking");
    private readonly int HashAttack = Animator.StringToHash("Attack");
    private readonly int HashHit = Animator.StringToHash("Hit");
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _data = GetComponent<EnemyData>();
        _chase = GetComponent<EnemyChase>();
    }

    private void Update()
    {
        if (_state == EnemyState.Hit) return;

        _animator.SetBool(HashIsWalking, _data.isWalking);
        
        if (_data.dirVec.sqrMagnitude < _data.attackRangeSqr)
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
        
        if (_data.dirVec.sqrMagnitude < _data.detectionRangeSqr)
        {
            _state = EnemyState.Chase;
            _chase.enabled = true;
        }
    }
    
    private void Attack()
    {
        StopAllCoroutines();
        StartCoroutine(AttackProcess());
    }
    
    private IEnumerator AttackProcess()
    {
        _animator.SetTrigger(HashAttack);
        
        _chase.enabled = false;
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _state = EnemyState.Attack;
        
        yield return new WaitForSeconds(0.5f);

        _rb.bodyType = RigidbodyType2D.Dynamic;
        _state = EnemyState.Idle;
    }

    public void OnHit(int damage = 0)
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
}
