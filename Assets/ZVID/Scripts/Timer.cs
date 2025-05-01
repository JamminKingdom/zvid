using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text; 

    void Update()
    {
        // sec += Time.deltaTime;
        //
        // if (sec >= 60)
        // {
        //     sec = 0;
        //     min++;
        // }
        
        int min = Mathf.FloorToInt(TimeManager.Instance.ElapsedTime / 60f);
        int sec = Mathf.FloorToInt(TimeManager.Instance.ElapsedTime % 60f);
        
        text.text = $"{min:00}:{sec:00}";
    }
}
