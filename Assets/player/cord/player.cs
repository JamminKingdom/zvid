using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    public GameObject play;
    public float Speed = 5f;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    
    private SpriteRenderer sp;

    public Rigidbody2D rb;
    
    private Vector2 dir;

    private Animator anim;

    public int maxBulletsInScene = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Projectile projectile = bulletGO.GetComponent<Projectile>();
            
            if (sp.flipX == true)
            {
                Vector2 left = Vector2.left;
                projectile.SetDirection(left);
            }
            else
            {
                Vector2 right = Vector2.right;
                projectile.SetDirection(right);
                
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Shoot()
    {
        if (GameObject.FindGameObjectWithTag("Bullet").layer < maxBulletsInScene)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    private void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        dir = new Vector2(h, v);
        rb.MovePosition(rb.position + Speed * Time.deltaTime * dir);

        if (dir == Vector2.zero)
        {
            anim.SetBool("player", false);
        }

        if (dir != Vector2.zero)
        {
            anim.SetBool("player", true);
        }

        if (h < 0)
        {
            sp.flipX = true;
        }
        else if(h > 0)
        {
            sp.flipX = false;
        }
    }
}
