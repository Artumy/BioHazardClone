using UnityEngine;

[RequireComponent(typeof(Cell))]
[RequireComponent(typeof(SpriteRenderer))]
public class TapOnCells : MonoBehaviour
{
    [SerializeField] private DrawLineDirection _lineDirection;
    [SerializeField] private GameObject _cellsObject;

    private TapOnCells[] _tapOnCells;
    private Cell[] _cells;

    private Cell _cell;
    private bool _isActive;

    private int _countOfChild;

    public bool IsActive => _isActive;

    private void Start()
    {
        _countOfChild = _cellsObject.transform.childCount;
        _cells = _cellsObject.GetComponentsInChildren<Cell>();
        _tapOnCells = _cellsObject.GetComponentsInChildren<TapOnCells>();
        _cell = GetComponent<Cell>();
        _isActive = false;
    }

    private void OnMouseDown()
    {
        if (_cell.Type == Cell.CellType.Player)
            _lineDirection.SetStartPositionLine();
        _isActive = true;
    }

    private void OnMouseEnter()
    {
        for (int i = 0; i < _countOfChild; i++)
        {
            if (_tapOnCells[i].IsActive == true)
            {
                if (_cell.Type == Cell.CellType.Player)
                {
                    _lineDirection.SetStartPositionLine();
                    _isActive = true;
                }
            }
        }
    }

    private void Update()
    {
        _lineDirection.DrawLine();
    }

    private void OnMouseUp()
    {
        for (int i = 0; i < _countOfChild; i++)
        {
            if (_tapOnCells[i]._isActive == true)
            {
                _cells[i].SpawnEntity(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            if (_tapOnCells[i]._lineDirection.Line.enabled == true)
            {
                _tapOnCells[i]._lineDirection.EndDrawLine();
                _tapOnCells[i]._isActive = false;
            }
        }
    }
}
