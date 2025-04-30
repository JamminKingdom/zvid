using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public int MaxHp = 50;
    
    public int Hp
    {
        get => _hp;
        set
        {
            if (_hp == value)
                return;

            var newValue = Mathf.Clamp(value, 0, MaxHp);
            
            _hp = newValue;
        }
    }
    private int _hp;
    [HideInInspector]
    public int attackDamage = 10;
    [HideInInspector]
    public float knockbackForce = 10f;
    [HideInInspector]
    public float knockbackDuration = 0.2f;
    [HideInInspector]
    public bool isWalking;
    [HideInInspector]
    public float detectionRangeSqr = 40f;
    [HideInInspector]
    public float attackRangeSqr = 15f;
    [HideInInspector]
    public Vector2 dirVec;
    
    [HideInInspector]
    public readonly int HashIsWalking = Animator.StringToHash("IsWalking");
    [HideInInspector]
    public readonly int HashAttack = Animator.StringToHash("Attack");
    [HideInInspector]
    public readonly int HashHit = Animator.StringToHash("Hit");
    [HideInInspector]
    public readonly int HashDead = Animator.StringToHash("Dead");

    private void Awake()
    {
        target = Player.Instance.transform;
        
        _hp = MaxHp;
        dirVec = new(1000000f, 1000000f);
    }

    private void Update()
    {
        dirVec = Player.Instance.transform.position - transform.position;
        isWalking = dirVec.sqrMagnitude < detectionRangeSqr;
    }
}
