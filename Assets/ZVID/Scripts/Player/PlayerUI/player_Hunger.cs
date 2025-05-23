using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class player_Hunger : MonoBehaviour
{
    public int strength = 100;
    public int currentHealth;
    
    public Image HungerFillImage;
    public float maxHunger = 100f;

    public float Hunger = 100f;
    
    private void Start()
    {
        currentHealth = strength;
    }

    public void Update()
    {
        Hunger -= Time.deltaTime * 2f;
        Hunger = Mathf.Clamp(Hunger, 0, maxHunger);

        HungerFillImage.fillAmount = Hunger / maxHunger;
    }
}
