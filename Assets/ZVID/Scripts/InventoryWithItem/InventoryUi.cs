using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    [SerializeField] 
    private Image[] items;

    [SerializeField] 
    private TMP_Text[] count;
    
    [SerializeField] 
    private CanvasGroup canvasgroup;
    
    public TextMeshProUGUI discriptionText;
    
    public TextMeshProUGUI nameText;
    
    public Image itemImage;
    
    public static bool inventoryOpen;
    
    private float currentTime;
    
    public ItemManager itemManager;
    
    // public GameObject statebar;

    public GameObject bar;
    
    private Vector3 originalPosition;
    
    private Vector3 position;

    private void Start()
    {
        inventoryOpen = false;
        canvasgroup.alpha = 0f;
        
        originalPosition = bar.transform.localPosition;
        position = new Vector3(320f, 155f, 0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !inventoryOpen)
        {
            // Debug.Log("Inventory Open");
            // statebar.SetActive(false);
            bar.transform.localPosition = position;
            
            canvasgroup.alpha = 1f;
            currentTime = Time.timeScale;
            Time.timeScale = 0f;
            inventoryOpen = true;
            return;
        }

        if (Input.GetKeyDown(KeyCode.I) && inventoryOpen)
        {
            // Debug.Log("Inventory Close");
            // statebar.SetActive(true);
            bar.transform.localPosition = originalPosition;
            
            canvasgroup.alpha = 0f;
            Time.timeScale = currentTime;
            inventoryOpen = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && inventoryOpen && Slot.isSelected)
        {
            itemManager.Use(int.Parse(Slot.slot.name));
        }



        if (!Slot.slot)
        {
            discriptionText.text = "";
            nameText.text = "";
            itemImage.sprite = itemManager.itemData[0].sprite;
        }
        else
        {
            int type = itemManager.presentType(int.Parse(Slot.slot.name));
            
            discriptionText.text = itemManager.itemData[type].description;
            nameText.text = itemManager.itemData[type].name;
            itemImage.sprite = itemManager.itemData[type].sprite;
        }

    }

    public void ItemLook(ItemType type, int amount, int index)
    {
        // Debug.Log($"ItemLock {type} {amount} {index}");
        
        items[index].sprite = itemManager.itemData[(int)type].sprite;
        
        count[index].text = amount.ToString();
        
        if (amount <= 0)
        {
            count[index].text = "";
            items[index].sprite = itemManager.itemData[0].sprite;
        }
        
    }
}
    
