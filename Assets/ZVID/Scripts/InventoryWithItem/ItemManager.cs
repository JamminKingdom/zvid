
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public InventoryUi inventory;

    [SerializeField] private InventoryData[] itemList = new InventoryData[15];

    public void Add(ItemType type, int amount)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i].type == type)
            {
                itemList[i].amount += amount;

                inventory.ItemLook(itemList[i].type, itemList[i].amount, itemList[i].index);

                return;
            }

        }

        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i].type == ItemType.None)
            {
                InventoryData inventoryData = new InventoryData();

                inventoryData.type = type;
                inventoryData.amount = amount;
                inventoryData.index = i;

                itemList[i] = inventoryData;

                inventory.ItemLook(itemList[i].type, itemList[i].amount, itemList[i].index);

                return;
            }
        }
    }

    public void Use(int index)
    {
        Debug.Log($"사용 {itemList[index].type}");
        
        if (itemList[index].type == ItemType.None)
        {
            return;
        }

        itemList[index].amount--;
        inventory.ItemLook(itemList[index].type, itemList[index].amount, itemList[index].index);

        if (itemList[index].amount <= 0)
        {
            itemList[index].type = ItemType.None;
            itemList[index].amount = 0;
        }
    }
}

