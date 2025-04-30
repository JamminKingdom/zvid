using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    [SerializeField] 
    private Image[] items;

    [SerializeField] 
    private TMP_Text[] count;
    
    [SerializeField] 
    private CanvasGroup canvasgroup;
    
    public TextMeshProUGUI discriptionText;
    
    public TextMeshProUGUI nameText;
    
    public Image itemImage;
    
    public static bool inventoryOpen;
    
    private float currentTime;

    public GameObject bar;
    
    private Vector3 originalPosition;
    
    private Vector3 position;
    
    
    
    // private RectTransform[] originRectTransform = new RectTransform[15];
    //
    // private void Awake()
    // {
    //     for (int i = 0; i < items.Length; i++)
    //     {
    //         originRectTransform[i] = items[i].rectTransform;
    //     }
    // }
    private void Start()
    {
        inventoryOpen = false;
        canvasgroup.alpha = 0f;
        
        originalPosition = bar.transform.localPosition;
        position = new Vector3(320f, 155f, 0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !inventoryOpen)
        {
            bar.transform.localPosition = position;
            
            canvasgroup.alpha = 1f;
            currentTime = Time.timeScale;
            Time.timeScale = 0f;
            inventoryOpen = true;
            return;
        }

        if (Input.GetKeyDown(KeyCode.I) && inventoryOpen)
        {
            bar.transform.localPosition = originalPosition;
            
            canvasgroup.alpha = 0f;
            Time.timeScale = currentTime;
            inventoryOpen = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && inventoryOpen && Slot.isSelected)
        {
            ItemManager.Instance.Use(int.Parse(Slot.slot.name));
        }



        if (!Slot.slot)
        {
            discriptionText.text = "";
            nameText.text = "";
            itemImage.sprite = ItemManager.Instance.itemData[0].sprite;
        }
        else
        {
            int type = ItemManager.Instance.presentType(int.Parse(Slot.slot.name));
            
            discriptionText.text = ItemManager.Instance.itemData[type].description;
            nameText.text = ItemManager.Instance.itemData[type].name;
            itemImage.sprite = ItemManager.Instance.itemData[type].sprite;
        }

    }

    public void ItemLook(ItemType type, int amount, int index)
    {
        items[index].sprite = ItemManager.Instance.itemData[(int)type].sprite;
        
        count[index].text = amount.ToString();
        
        if (amount <= 0)
        {
            count[index].text = "";
            items[index].sprite = ItemManager.Instance.itemData[0].sprite;
        }
    }

    // public void MovePosition(Vector2 pos, int index)
    // { 
    //     items[index].rectTransform.position = pos;
    // }
    //
    // public void ResetPosition(int index)
    // {
    //     items[index].rectTransform.position = originRectTransform[index].position;
    // }
}
    
