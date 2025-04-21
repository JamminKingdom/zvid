using System;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image image;
    
    public static Slot slot;

    public static int slotType;
    
    public static bool isSelected;
    
    private void Start()
    {
        image.color = new Color(1f, 1f, 1f, 0f);
    }

    private void Update()
    {
    }

    public void Open()
    {
        if (!InventoryUi.inventoryOpen)
        {
            return;
        }

        // Debug.Log($"Open {gameObject.name}");

        if (slot != null)
        {
            slot.Close();
        }

        if (slot == this)
        {
            slot = null;
            slotType = 0;
        }
        else
        {
            image.color = new Color(1f, 1f, 1f, 1f);
            isSelected = true;
            slot = this;
            slotType = 1;
        }
    }

    public void Close()
    {
        // Debug.Log($"Close {gameObject.name}");
        isSelected = false;
        image.color = new Color(1f, 1f, 1f, 0f);
    }
}
