using UnityEngine;

public class StartFadeOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject UIObject;
    
    private bool _isFading;
    private float _fadeDuration = 1f;
    private float _timer;
    
    void Start()
    {
        Time.timeScale = 0f;
        _isFading = false;
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = canvasGroup.blocksRaycasts = true;
    }

    void Update()
    {
        if (_isFading)
        {
            _timer += Time.unscaledDeltaTime;

            float alpha = Mathf.Lerp(1f, 0f, _timer / _fadeDuration);

            canvasGroup.alpha = alpha;

            if (alpha <= 0f)
            {
                canvasGroup.interactable = canvasGroup.blocksRaycasts = false;

                _isFading = false;
                gameObject.SetActive(false);
                UIObject.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }

    public void StartFadeIn()
    {
       _isFading = true;
       AudioManager.Instance.PlaySFX(SFXType.StartButton);
    }
    
}
