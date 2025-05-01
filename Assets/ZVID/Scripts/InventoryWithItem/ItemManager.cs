using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public InventoryUi inventory;

    public ItemData[] itemData = new ItemData[7];

    [SerializeField] private InventoryData[] itemList = new InventoryData[15];
    
    public player_wataer wataer;
    public player_Hunger hunger;
    public player_stebba statebar;
    public player_Disease disease;
    
    private InventoryData dragData;
    private InventoryData dropData;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }
    
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
        AudioManager.Instance.PlaySFX(SFXType.ItemUse);
        
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
            disease.CureDisease();
        }
    }

    public int presentType(int index)
    {
        return (int) itemList[index].type;
    }

    public void ChangeData(int dragIndex, int dropIndex)
    {
        
        dragData = itemList[dragIndex];
        dropData = itemList[dropIndex];
        
        dragData.index = dropIndex;
        dropData.index = dragIndex;
        
        itemList[dragIndex] = dropData;
        itemList[dropIndex] = dragData;

        if (itemList[dragIndex].type == ItemType.None)
        {
            itemList[dragIndex].index = 0;
        }

        if (itemList[dropIndex].type == ItemType.None)
        {
            itemList[dropIndex].index = 0;
        }
        
        inventory.ItemLook(itemList[dragIndex].type, itemList[dragIndex].amount, dragIndex);
        inventory.ItemLook(itemList[dropIndex].type, itemList[dropIndex].amount, dropIndex);
    }
}

