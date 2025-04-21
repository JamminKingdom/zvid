using System;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    
    private int _hp;
    
    public int Health
    {
        get => _hp;
        set
        {
            int newValue = Math.Clamp(value, 0, 100);
            _hp = newValue;
        }
    }
    
    
    
}
