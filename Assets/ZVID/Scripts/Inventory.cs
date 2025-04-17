using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject itemPrefab;

    public Transform[] slots;
    
    public Sprite[] itemSprites;
    
    public ItemManager itemManager;
    
    private GameObject[] itemList = new GameObject[15];
    
    

    private void Start()
    {
        // AddItem(ItemType.LargeFood, 1, 4);
        //
        // AddItem(ItemType.LargeDrink, 1, 2);
        //
        // AddItem(ItemType.SmallDrink, 1, 8);
        //
        // AddItem(ItemType.CurePotion, 1, 3);
        //
        // AddItem(ItemType.HealPotion, 1, 1);
        //
        // AddItem(ItemType.SmallFood, 1, 10);

    }

    private void Update()
    {
        
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //
        //     // DeleteItem(4);
        //     // DeleteItem(8);
        //     //
        //     // DeleteItem(3);
        //     //
        //     // DeleteItem(1);
        //     
        //     
        //
        // }
    }

    public void AddItem(ItemType type, int amount, int index)
    {
        GameObject go = Instantiate(itemPrefab);
        
        go.name = type.ToString();

        itemList[index] = go;
        
        go.transform.SetParent(slots[index].transform);
        go.transform.localPosition = Vector3.zero;
        
        Image IM = go.GetComponent<Image>();
        
        
        Sprite sprite = itemSprites[(int)type - 1];
        
        IM.sprite = sprite;

    }

    public void DeleteItem(int index)
    {
        GameObject go = itemList[index];
        itemList[index] = null;
        Destroy(go);
    }
}
