using UnityEngine;

public class test : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    private Rigidbody2D rb;
    private Vector2 targetVelocity;
    private float moveSpeed = 5f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(moveX, moveY);
        if (inputVector.magnitude > 1)
            inputVector.Normalize();
        
        targetVelocity = inputVector * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            enemyMovement.TakeDamage(10);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = targetVelocity;
    }
}
