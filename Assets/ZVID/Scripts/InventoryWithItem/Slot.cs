using System;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image image;
    
    public static Slot slot;
    
    public static bool isSelected;
    
    private void Start()
    {
        image.color = new Color(1f, 1f, 1f, 0f);
    }

    public void Open()
    {
        if (!InventoryUi.inventoryOpen)
        {
            return;
        }

        if (slot != null)
        {
            slot.Close();
        }

        if (slot == this)
        {
            slot = null;
        }
        else
        {
            image.color = new Color(1f, 1f, 1f, 1f);
            isSelected = true;
            slot = this; 
        }
    }

    public void Close()
    {
        isSelected = false;
        image.color = new Color(1f, 1f, 1f, 0f);
    }
}
