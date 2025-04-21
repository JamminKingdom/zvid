
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public InventoryUi inventory;

    [SerializeField] private ItemData[] itemList = new ItemData[15];

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
                ItemData itemData = new ItemData();

                itemData.type = type;
                itemData.amount = amount;
                itemData.index = i;

                itemList[i] = itemData;

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

