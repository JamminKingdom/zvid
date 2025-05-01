using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private ItemType _itemType;
    private int layerMaskPlayer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(ItemData data)
    {
        _spriteRenderer.sprite = data.sprite;
        _itemType = data.type;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ItemManager.Instance.Add(_itemType);
            AudioManager.Instance.PlaySFX(SFXType.ItemPickup);
            Destroy(gameObject);
        }
    }
}
