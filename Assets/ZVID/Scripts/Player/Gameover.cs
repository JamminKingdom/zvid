using System.Collections;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Coroutine fadeCoroutine;
    private float fadeDuration = 1f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = canvasGroup.blocksRaycasts = false;
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
        canvasGroup.interactable = canvasGroup.blocksRaycasts = true;

        fadeCoroutine = null;
        
        yield return new WaitForSecondsRealtime(3f);

        RankingManager.Instance.AddRecord(
            GameManager.Instance.killCnt,
            TimeManager.Instance.ElapsedTime
        );
        
        gameObject.SetActive(false);
    }
}
