using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class player_wataer : MonoBehaviour
{
    public int strength = 100;
    public int currentHealth;
    private Slider healthBar;
    
    public Image waterFillImage;
    public float maxWater = 100f;

    //게이지 물
    public float wataer = 100f;
    
    private void Start()
    {
        currentHealth = strength;
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
    }

    public void Update() 
    {
        wataer -= Time.deltaTime;
        wataer = Mathf.Clamp(wataer, 0, maxWater);

        waterFillImage.fillAmount = wataer / maxWater;
    }
}
