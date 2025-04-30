using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject gameOverUI;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = gameOverUI.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        gameOverUI.SetActive(false);
    }

    public void over()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(ShowGameOverUI());
    }

    private IEnumerator ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        yield return new WaitForEndOfFrame();
        
        float t = 0f;
        
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime;
            canvasGroup.alpha = t;
            yield return null;
        }
        
        canvasGroup.alpha = 1f;
    }
}
