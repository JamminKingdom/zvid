using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyStateBase : MonoBehaviour
{
    protected Animator anim { get; private set; }
    protected EnemyData data { get; private set; }
    protected Enemy enemy { get; private set; }
    protected SpriteRenderer spriteRenderer { get; private set; }
    protected Rigidbody2D rb { get; private set; }
    protected NavMeshAgent agent { get; private set; }
    protected Collider2D collider { get; private set; }

    protected virtual void Awake()
    {
        anim  = GetComponent<Animator>();
        data  = GetComponent<EnemyData>();
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        collider = GetComponent<Collider2D>();
    }
}