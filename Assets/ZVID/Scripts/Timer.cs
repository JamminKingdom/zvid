using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text; 
    
    private float min = 0;
    private float sec = 0;

    void Update()
    {
        sec += Time.deltaTime; //테스트 코드 => 아래 TimeManager가 실행되고있는 환경에서 실행 필요
        // sec = TimeManager.Instance.ElapsedTime;
        
        if (sec >= 60)
        {
            sec = 0;
            min++;
        }
        
        text.text = $"{min:00}:{sec:00}";
    }
}
