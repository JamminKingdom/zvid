using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    [SerializeField] 
    private Sprite[] itemSprites;
    
    [SerializeField] 
    private Image[] items;

    [SerializeField] 
    private TMP_Text[] count;
    
    [SerializeField] 
    private CanvasGroup canvasgroup;
    
    public static bool inventoryOpen;
    
    private float currentTime;
    
    public ItemManager itemManager;

    private void Start()
    {
        inventoryOpen = false;
        canvasgroup.alpha = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !inventoryOpen)
        {
            // Debug.Log("Inventory Open");
            canvasgroup.alpha = 1f;
            currentTime = Time.timeScale;
            Time.timeScale = 0f;
            inventoryOpen = true;
            return;
        }

        if (Input.GetKeyDown(KeyCode.I) && inventoryOpen)
        {
            // Debug.Log("Inventory Close");
            canvasgroup.alpha = 0f;
            Time.timeScale = currentTime;
            inventoryOpen = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && inventoryOpen && Slot.isSelected)
        {
            itemManager.Use(int.Parse(Slot.slot.name));
        }
        
    }

    public void ItemLook(ItemType type, int amount, int index)
    {
        // Debug.Log($"ItemLock {type} {amount} {index}");
        
        items[index].sprite = itemSprites[(int)type];
        
        count[index].text = amount.ToString();
        
        if (amount <= 0)
        {
            count[index].text = "";
            items[index].sprite = itemSprites[0];
        }
        
    }
    
}
    
