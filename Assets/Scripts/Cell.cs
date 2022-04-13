using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private CellType _type;

    private SpriteRenderer _spriteRenderer;

    public CellType Type => _type;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetColor();
    }

    private void SetColor()
    {
        if (_type == CellType.None)
        {
            _spriteRenderer.color = Color.gray;
        }
        else if (_type == CellType.Player)
        {
            _spriteRenderer.color = Color.green;
        }
        else
        {
            _spriteRenderer.color = Color.red;
        }
    }

    public enum CellType
    {
        Player,
        Enemy,
        None
    }
}
