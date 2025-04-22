using System;
using UnityEngine;
using UnityEngine.Rendering;

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
                Debug.Log(true); //  왼
                Vector2 left = Vector2.left;
                Debug.Log(left);
                projectile.SetDirection(left);
            }
            else
            {
                Debug.Log(false);// 오
                Vector2 right = Vector2.right;
                Debug.Log(right);
                projectile.SetDirection(right);
                
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
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
        else
        {
            sp.flipX = false;
        }
    }
}
