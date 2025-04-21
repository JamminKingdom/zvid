using System;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    
    private Rigidbody2D _rb;
    private EnemyData _data;
    
    private readonly float speedAccelerationRate = 100000f;
    private readonly float minSpeed = 0.1f;
    private readonly float maxSpeed = 5f;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _data = GetComponent<EnemyData>();
    } 

    private void Update()
    {
        moveSpeed = Mathf.Clamp(moveSpeed + TimeManager.Instance.ElapsedTime / speedAccelerationRate, minSpeed, maxSpeed);
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = moveSpeed * Time.fixedDeltaTime * _data.dirVec.normalized;
            
        _rb.MovePosition(_rb.position + nextVec);
        _rb.linearVelocity = Vector2.zero;
    }
}