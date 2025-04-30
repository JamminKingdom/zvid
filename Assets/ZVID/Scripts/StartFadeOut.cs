using UnityEngine;

public class StartFadeOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    
    private bool _isFading;
    
    private float _fadeDuration = 1f;
    
    private float _timer;
    void Start()
    {
        Time.timeScale = 0f;
        _isFading = false;
        canvasGroup.alpha = 1f;
    }

    void Update()
    {
        if (_isFading)
        {
            Debug.Log("페이딩 시작" );
            _timer += Time.unscaledDeltaTime;

            float alpha = Mathf.Lerp(1f, 0f, _timer / _fadeDuration);

            canvasGroup.alpha = alpha;

            if (alpha <= 0f)
            {
                _isFading = false;
                this.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void StartFadeIn()
    {
       _isFading = true;
    }
    
}
