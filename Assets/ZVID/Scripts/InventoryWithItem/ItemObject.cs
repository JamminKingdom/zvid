using System;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(ItemData data)
    {
        _spriteRenderer.sprite = data.sprite;
    }
}
