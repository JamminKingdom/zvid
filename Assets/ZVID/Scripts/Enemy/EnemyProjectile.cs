using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class EnemyProjectile : MonoBehaviour
{
    public float lifetime = 5f;
    public float moveSpeed = 6f;

    private int _damage;
    private Rigidbody2D _rb;
    private LayerMask targetLayers;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        targetLayers = LayerMask.NameToLayer("Player");
    }
    
    public void Shot(int damage, Vector2 direction)
    {
        _damage = damage;

        _rb.linearVelocity = direction.normalized * moveSpeed;

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == targetLayers)
        {
            //Player TakeDamage
            Debug.Log("Player Hit");
            Destroy(gameObject);
        }
    }
}