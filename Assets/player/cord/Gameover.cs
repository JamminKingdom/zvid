using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject gameOverUI;
    
    public void over()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
