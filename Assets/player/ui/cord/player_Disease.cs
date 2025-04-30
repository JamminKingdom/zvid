using System.Collections;
using UnityEngine;

public class player_Disease : MonoBehaviour
{
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
