using UnityEngine;

public class player_Disease : MonoBehaviour
{
    public player_stebba PlayerStebba; 
    
    public bool isSick;
    
    public void GetDisease()
    {
        isSick = true;
    }

    public void CureDisease()
    {
        isSick = false;
    }
    
    
}
