using UnityEngine;
using UnityEngine.UI;

public class player_stebba : MonoBehaviour
{
    public float maxStebba = 100f;
    public float Stebba = 100f;
    public Image StebbaFillImage;

    public player_wataer PlayerWataer;
    public player_Hunger PlayerHunger;

    private void Start()
    {
        StebbaFillImage.fillAmount = 1f;
    }

    public void Update()
    {
        if (PlayerWataer.wataer <= 0.00001f)
        {
            Stebba -= Time.deltaTime * 2;
        }
        
        if (PlayerHunger.Hunger <= 0.00001f)
        {
            Stebba -= Time.deltaTime * 2;
        }

        if (PlayerWataer.wataer >= 99.9999f)
        {
            Stebba += Time.deltaTime * 1;
        }

        if (PlayerHunger.Hunger >= 99.9999f)
        {
            Stebba += Time.deltaTime * 1;
        }
        Stebba = Mathf.Clamp(Stebba, 0, maxStebba);

        StebbaFillImage.fillAmount = Stebba / maxStebba;
    }

    public void TakeDamage(float damage)
    {
        Stebba -= damage;
        if (Stebba <= 0)
        {
            Debug.Log("사망");
        }
    }
}
