using UnityEngine;

public class test : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask enemyLayerMask;
    
    private Rigidbody2D rb;
    private Vector2 targetVelocity;
    private SpriteRenderer _spriteRenderer;
    private float moveSpeed = 5f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        enemyLayerMask = LayerMask.GetMask("Enemy");
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(moveX, moveY);
        if (inputVector.sqrMagnitude > 1f)
        {
            inputVector.Normalize();
        }
        
        if (inputVector.sqrMagnitude > 0f)
        {
            _spriteRenderer.flipX = inputVector.x < 0f;
        }
        
        targetVelocity = moveSpeed * inputVector;
        if (Input.GetMouseButtonDown(0))
        {
            TryKillEnemyAtMouse();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = targetVelocity;
    }
    
    private void TryKillEnemyAtMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z;
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        Vector2 worldPos2D = new Vector2(worldPos.x, worldPos.y);

        Collider2D hit = Physics2D.OverlapPoint(worldPos2D, enemyLayerMask);
        if (hit == null)
            return;

        EnemyMovement enemy = hit.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.TakeDamage(int.MaxValue);
        }
    }
}
