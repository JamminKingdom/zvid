using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 20;

    private Vector2 direction;
    private LayerMask targetLayers;

    private void Awake()
    {
        targetLayers = LayerMask.NameToLayer("Enemy");
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == targetLayers)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
