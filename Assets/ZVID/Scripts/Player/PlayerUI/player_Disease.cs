using UnityEngine;
using UnityEngine.UI;

public class player_Disease : MonoBehaviour
{
    public bool isSick;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void GetDisease()
    {
        isSick = true;
        _image.enabled = true;
    }

    public void CureDisease()
    {
        isSick = false;
        _image.enabled = false;
    }
}
