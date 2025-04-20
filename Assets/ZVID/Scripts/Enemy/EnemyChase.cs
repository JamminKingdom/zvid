using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 1f;
    
    private Rigidbody2D _rb;
    private EnemyData _data;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _data = GetComponent<EnemyData>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = moveSpeed * Time.fixedDeltaTime * _data.dirVec.normalized;
            
        _rb.MovePosition(_rb.position + nextVec);
        _rb.linearVelocity = Vector2.zero;
    }
}