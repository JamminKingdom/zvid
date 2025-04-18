using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject play;
    public float Speed = 1f;
    public SpriteRenderer sp;

    public Rigidbody2D rb;
    
    private Vector2 dir;

    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
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
