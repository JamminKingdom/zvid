using UnityEngine;

public class Testt : MonoBehaviour
{
    public ItemManager im;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            im.Add(ItemType.LargeFood, 1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            im.Add(ItemType.LargeDrink, 1);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            im.Add(ItemType.HealPotion, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            im.Use(ItemType.LargeFood);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            im.Use(ItemType.LargeDrink);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            im.Use(ItemType.HealPotion);
        }
    }
}
