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
        sec += Time.deltaTime;
        
        if (sec >= 60)
        {
            sec = 0;
            min++;
        }
        
        text.text = $"{min:00}:{sec:00}";
    }
}
