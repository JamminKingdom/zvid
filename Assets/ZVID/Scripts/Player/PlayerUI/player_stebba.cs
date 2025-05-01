using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class player_stebba : MonoBehaviour
{
    public float maxStebba = 100f;
    [HideInInspector] public float Stebba = 100f;

    public Image StebbaFillImage;

    private float displayFill;
    private bool isDead;

    public player_wataer PlayerWataer;
    public player_Hunger PlayerHunger;
    public player_Disease PlayerDisease;
    public Gameover over;
    public GameObject ui;

    private void Start()
    {
        Stebba = maxStebba;
        displayFill = 1f;
        StebbaFillImage.fillAmount = displayFill;
    }
    
    private void Update()
    {
        if (isDead) return;
        
        if (PlayerWataer.wataer <= 0.00001f)
        {
            Stebba -= Time.deltaTime * 2;
        }
        
        if (PlayerHunger.Hunger <= 0.00001f)
        {
            Stebba -= Time.deltaTime * 2;
        }
        
        if (PlayerDisease.isSick)
        {
            Stebba -= Time.deltaTime;
        }

        float targetFill = Stebba / maxStebba;

        StebbaFillImage.fillAmount = targetFill;
        
        Stebba = Mathf.Clamp(Stebba, 0, maxStebba);

        if (Stebba <= 0f)
            Die();
    }

    public void TakeDamage(float damage)
    {
        if (isDead || Player.Instance.isHit) return;

        Player.Instance.Hit();

        Stebba -= damage;
        Stebba = Mathf.Clamp(Stebba, 0, maxStebba);

        if (Stebba <= 0f)
        {
            Die();
            return;
        }

        if (Random.Range(1, 11) == 1)
            PlayerDisease.GetDisease();
    }

    private void Die()
    {
        AudioManager.Instance.StopBGM();
        AudioManager.Instance.PlaySFX(SFXType.PlayerDead);
        isDead = true;
        ui.SetActive(false);
        over.over();
    }
}