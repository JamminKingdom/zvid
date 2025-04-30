using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class player_stebba : MonoBehaviour
{
    public float maxStebba = 100f;
    public float Stebba = 100f;
    public Image StebbaFillImage;
    public SpriteRenderer sr;
    
    public player_wataer PlayerWataer;
    public player_Hunger PlayerHunger;
    public player_Disease PlayerDisease;

    public Gameover over;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StebbaFillImage.fillAmount = 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Player.Instance.Hit();
        
        if (PlayerDisease.isSick)
        {
            Stebba -= Time.deltaTime * 1;
        }
        
        if (PlayerWataer.wataer <= 0.00001f)
        {
            Stebba -= Time.deltaTime * 2;
        }
        
        if (PlayerHunger.Hunger <= 0.00001f)
        {
            Stebba -= Time.deltaTime * 2;
        }

        if (PlayerWataer.wataer >= 99.9999f)
        {
            Stebba += Time.deltaTime * 1;
        }

        if (PlayerHunger.Hunger >= 99.9999f)
        {
            Stebba += Time.deltaTime * 1;
        }

        
        Stebba = Mathf.Clamp(Stebba, 0, maxStebba);

        StebbaFillImage.fillAmount = Stebba / maxStebba;
        
        if (Stebba <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        Player.Instance.Hit();
        
        Stebba -= damage;
        if (Stebba <= 0)
        {
            Die();
            return;
        }

        int pattern = Random.Range(1, 11);

        if (pattern == 1)
        {
            PlayerDisease.GetDisease(); 
        }
    }

    public void Die()
    {
        over.over();
        Debug.Log("사망");
    }
}
