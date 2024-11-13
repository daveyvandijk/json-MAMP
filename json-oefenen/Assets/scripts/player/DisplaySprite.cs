using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySprite : MonoBehaviour
{
    public WapenScriptableObject huidigWapenData;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (huidigWapenData != null && _spriteRenderer != null)
        {
            _spriteRenderer.sprite = huidigWapenData.WapenSprite;
            
        }
    }

    public void UpdateSprite()
    {
        if (_spriteRenderer != null && huidigWapenData != null)
        {
            _spriteRenderer.sprite = huidigWapenData.WapenSprite;
        }
    }
}