using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D target;
    
    public float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 dirVec = target.position - rb.position;
        Vector2 nextVec = moveSpeed * Time.fixedDeltaTime * dirVec.normalized;
        if (nextVec.x > 0)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
        rb.MovePosition(rb.position + nextVec);
        rb.linearVelocity = Vector2.zero;
    }
}
