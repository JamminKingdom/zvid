using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    private Vector2 direction;
    
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
        Debug.Log(dir);
        direction = dir;
    }
}
