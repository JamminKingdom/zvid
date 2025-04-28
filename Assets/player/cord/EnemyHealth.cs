using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 30f;
    private float currentHealth;
    private float Damages = 5f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void GettingDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        { 
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            GettingDamage(Damages);
        }
    }
    
    
}
