
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public InventoryUi inventory;

    public ItemData[] itemData = new ItemData[7];

    [SerializeField] private InventoryData[] itemList = new InventoryData[15];
    
    public player_wataer wataer;
    public player_Hunger hunger;
    public player_stebba statebar;

    public void Add(ItemType type)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i].type == type)
            {
                itemList[i].amount++;

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
                inventoryData.amount = 1;
                inventoryData.index = i;

                itemList[i] = inventoryData;

                inventory.ItemLook(itemList[i].type, itemList[i].amount, itemList[i].index);

                return;
            }
        }
    }

    public void Use(int index)
    {
        // Debug.Log($"사용 {itemList[index].type}");

        if (itemList[index].type == ItemType.None)
        {
            return;
        }

        itemList[index].amount--;
        
        UseItem(itemList[index].type);
        
        inventory.ItemLook(itemList[index].type, itemList[index].amount, itemList[index].index);

        if (itemList[index].amount <= 0)
        {
            itemList[index].type = ItemType.None;
            itemList[index].amount = 0;
        }
    }


    private void UseItem(ItemType type)
    {
        if (type == 0)
        {
            return;
        }
        else if ((int)type == 1 || (int)type == 2)
        {
            hunger.Hunger += itemData[(int)type].value;
        }
        else if ((int)type == 3 || (int)type == 4)
        {
            wataer.wataer += itemData[(int)type].value;
        }
        else if ((int)type == 5)
        {
            statebar.Stebba += itemData[(int)type].value;
        }
        else if ((int)type == 6)
        {
            //질병관련 아이템 사용
        }
        

    }

    public int presentType(int index)
    {
        return (int) itemList[index].type;
    }
}

