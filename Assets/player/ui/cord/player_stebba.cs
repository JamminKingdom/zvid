using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class player_stebba : MonoBehaviour
{
    public int strength = 100;
    public int currentHealth;
    
    public float maxStebba = 100f;
    public float Stebba = 100f;
    public Image StebbaFillImage;

    public player_wataer PlayerWataer;
    public player_Hunger PlayerHunger;

    private void Start()
    {
        currentHealth = strength;
        StebbaFillImage.fillAmount = 1f;
    }

    public void Update()
    {
        if (PlayerWataer.wataer == 0)
        {
            Stebba -= Time.deltaTime * 2;
        }
        
        if (PlayerHunger.Hunger == 0)
        {
            Stebba -= Time.deltaTime * 2;
        }
        
        else if(currentHealth <= 0)
        {
            Debug.Log("플레이어 사망");
        }
        Stebba = Mathf.Clamp(Stebba, 0, maxStebba);

        StebbaFillImage.fillAmount = Stebba / maxStebba;
    }
}
