using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    public float Speed = 5f;
    public float attackDelay = 0.5f;

    private bool isAttack;
    private bool isHit;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    public player_stebba stebba;
    
    private SpriteRenderer sp;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 dir;

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
        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            isAttack = true;
            
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Projectile projectile = bulletGO.GetComponent<Projectile>();
            
            if (sp.flipX)
            {
                Vector2 left = Vector2.left;
                projectile.SetDirection(left);
            }
            else
            {
                Vector2 right = Vector2.right;
                projectile.SetDirection(right);
            }
            
            Invoke(nameof(AttackEnd), attackDelay);
        }
    }

    private void AttackEnd()
    {
        isAttack = false;
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
    
    public void Hit()
    {
        if (isHit)
            return;
        StartCoroutine(HitProcess());
    }
    
    private IEnumerator HitProcess()
    {
        isHit = true;
        Color temp = sp.color;
        sp.color = new Color(0.74f, 0.41f, 0.41f);

        yield return new WaitForSeconds(0.5f);

        isHit = false;
        sp.color = temp;
    }
}
