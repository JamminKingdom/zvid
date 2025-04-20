using UnityEngine;

public class Testt : MonoBehaviour
{
    public ItemManager im;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            im.Add(ItemType.LargeFood, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            im.Add(ItemType.LargeDrink, 1);

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            im.Add(ItemType.HealPotion, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            im.Add(ItemType.CurePotion, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            im.Add(ItemType.SmallDrink, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            im.Add(ItemType.SmallFood, 1);
        }
        
    }
}
