using System.Collections;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private float fadeDuration = 1f;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }

    public void over()
    {
        gameObject.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(ShowGameOverUI());
    }

    private IEnumerator ShowGameOverUI()
    {
        yield return new WaitForEndOfFrame();
        
        float t = 0f;
        
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }
        
        canvasGroup.alpha = 1f;
    }
}
