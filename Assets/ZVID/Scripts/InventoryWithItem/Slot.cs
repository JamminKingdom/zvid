using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image image;
    
    public static Slot slot;
    
    public static bool isSelected;
    
    private static bool isDragging;

    private static int OriginSortOrder;
    
    [SerializeField] private Canvas canvas;
    
    [SerializeField] private InventoryUi inventoryUi;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private GameObject itemUi;
    
    
    
    private void Start()
    {
        image.color = new Color(1f, 1f, 1f, 0f);
    }

    public void Open()
    {
        if (!InventoryUi.inventoryOpen)
        {
            return;
        }

        if (slot != null)
        {
            slot.Close();
        }

        if (slot == this)
        {
            slot = null;
        }
        else
        {
            image.color = new Color(1f, 1f, 1f, 1f);
            isSelected = true;
            slot = this; 
        }
    }

    public void Close()
    {
        isSelected = false;
        image.color = new Color(1f, 1f, 1f, 0f);
    }

    public void MovePosition(Vector2 pos)
    {
        itemUi.transform.position = pos;
    }

    public void ResetPosition()
    {
        itemUi.transform.localPosition = Vector3.zero;
    }
    
    #region Drag and Drop
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        int presentType = int.Parse(eventData.pointerDrag.name);

        if (itemManager.presentType(presentType) == 0)
        {
            return;
        }

        if (isDragging)
        {
            return;
        }

        isDragging = true;
        
        OriginSortOrder = canvas.sortingOrder;
        // Debug.Log("드래그시작");
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging)
        {
            return;
        }

        canvas.sortingOrder = 10000;
        MovePosition(eventData.position);
        // Debug.Log("드래그중");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragging)
        {
            return;
        }

        isDragging = false;
        
        ResetPosition();
        canvas.sortingOrder = OriginSortOrder;
        // Debug.Log("드래그 끝");
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!isDragging)
        {
            return;
        }

        isDragging = false;
        // Debug.Log(eventData.pointerDrag.name);
        // Debug.Log(gameObject.name);
        // itemManager.ChangeData(int.Parse(eventData.pointerDrag.name), int.Parse(gameObject.name));
        
        Slot draggingSlot = eventData.pointerDrag.GetComponent<Slot>();


        itemManager.ChangeData(int.Parse(eventData.pointerDrag.name), int.Parse(gameObject.name));
        
        ResetPosition();
        draggingSlot.ResetPosition();
        Open();
        canvas.sortingOrder = OriginSortOrder;
        Debug.Log("드롭실행");
    }

    #endregion
}
