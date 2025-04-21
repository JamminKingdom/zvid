using Unity.Mathematics;
using UnityEngine;

public class Testt : MonoBehaviour
{
    public ItemManager im;
    
    // public GameObject itemPrefab;
    //
    // public Transform[] itemSpawnPoints;
    
    void Start()
    {
        
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            im.Add(ItemType.LargeFood);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            im.Add(ItemType.LargeDrink);
        
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            im.Add(ItemType.HealPotion);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            im.Add(ItemType.CurePotion);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            im.Add(ItemType.SmallDrink);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            im.Add(ItemType.SmallFood);
        }
        
    }
}
