using UnityEngine;

[RequireComponent(typeof(Cell))]
[RequireComponent(typeof(SpriteRenderer))]
public class TapOnCells : MonoBehaviour
{
    private DrawLineDirection _lineDirection;
    private Cell _cell;

    private void Start()
    {
        _lineDirection = FindObjectOfType<DrawLineDirection>();
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
            _cell.SpawnEntity(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            _lineDirection.EndDrawLine();
        }
    }
}
