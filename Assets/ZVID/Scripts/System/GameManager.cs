using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text; 
    
    public static GameManager Instance { get; private set; }
    private int killCnt = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    public void AddKillCount()
    {
        text.text = $"Kill: {++killCnt}";
    }

}










