using System.Collections;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Coroutine fadeCoroutine;
    private float fadeDuration = 1f;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
    }

    public void over()
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);
        
        Time.timeScale = 0f;
        
        fadeCoroutine = StartCoroutine(ShowGameOverUI());
    }

    private IEnumerator ShowGameOverUI()
    {
        yield return new WaitForEndOfFrame();
        
        float t = 0f;
        
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }
        
        canvasGroup.alpha = 1f;
        fadeCoroutine = null;
    }
}
