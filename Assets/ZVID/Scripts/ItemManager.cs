
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public InventoryUi inventory;
    
    [SerializeField] 
    private ItemData[] itemList = new ItemData[15];
    
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

    public void Use(ItemType type)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i].type == type)
            {
                itemList[i].amount--;
                // IsUsed = true;
                // index = itemList[i].index;
                inventory.ItemLook(itemList[i].type, itemList[i].amount, itemList[i].index);

                if (itemList[i].amount <= 0)
                {
                    itemList[i].type = ItemType.None;
                    itemList[i].amount = 0;
                }

                return;
            }
        }
    }
}

