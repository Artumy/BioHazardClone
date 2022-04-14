using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapOnCells : MonoBehaviour
{
    [SerializeField] private DrawLineDirection _lineDirection;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        _lineDirection.SetStartPositionLine();
    }

    private void OnMouseDrag()
    {
        _lineDirection.DrawLine();
    }

    private void OnMouseEnter()
    {
        _spriteRenderer.enabled = false;
    }

    private void OnMouseExit()
    {
        _spriteRenderer.enabled = true;
    }

    private void OnMouseUp()
    {
        _lineDirection.EndDrawLine();
    }

    
}
