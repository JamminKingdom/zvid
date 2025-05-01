using UnityEngine;

public class testKill : MonoBehaviour
{
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Player.Instance.stebba.TakeDamage(100);
        }
    }
}
