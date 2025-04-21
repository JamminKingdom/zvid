using System;
using UnityEngine;

[Serializable]
public class ItemData
{
    public ItemType type;
    public string name;
    public string description;
    public int value;
    public int weight;
    public int amount;
    public Sprite sprite;
    
    public ItemData(ItemType type, string name, string description, int value, int amount, Sprite sprite)
    {
        this.type = type;
        this.name = name;
        this.description = description;
        this.value = value;
        this.amount = amount;
        this.sprite = sprite;
    }
}