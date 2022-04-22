using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cell))]
[RequireComponent(typeof(SpriteRenderer))]
public class TapOnCells : MonoBehaviour
{
    [SerializeField] private DrawLineDirection _lineDirection;

    private SpriteRenderer _spriteRenderer;
    private Cell _cell;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _cell = GetComponent<Cell>();
    }

    private void OnMouseDown()
    {
        if (_cell.Type == Cell.CellType.Player)
            _lineDirection.SetStartPositionLine();
    }

    private void OnMouseDrag()
    {
        _lineDirection.DrawLine();
    }

    private void OnMouseUp()
    {
        if (_cell.Type == Cell.CellType.Player)
        {
            _cell.SpawnEntity();
            _lineDirection.EndDrawLine();
        }
    }
}
