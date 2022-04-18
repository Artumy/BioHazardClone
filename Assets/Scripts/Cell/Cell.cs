using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Cell : MonoBehaviour
{
    [SerializeField] private CellType _type;
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _prefabEntity;

    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider;

    public CellType Type => _type;
    public int Capacity => _capacity;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_capacity == 0)
        {
            if (collision.gameObject.tag == "Player")
                _type = CellType.Player;
            else
                _type = CellType.Enemy;

            _capacity += 1;
            Destroy(collision.gameObject);
            return;
        }

        if (_type.ToString() == collision.gameObject.tag)
            _capacity += 1;
        else
            _capacity -= 1;

        if (_capacity == 0)
            _type = CellType.None;

        SetColor();
        Destroy(collision.gameObject);
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

    public void SpawnEntity(Vector3 positionToMove)
    {
        var count = _capacity / 2;
        _capacity -= count;
        Vector3 direction = (positionToMove - transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        for (int i = 0; i < count; i++)
        {
            var entity = Instantiate(_prefabEntity, transform.position, Quaternion.identity);            
            entity.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            Physics2D.IgnoreCollision(entity.GetComponent<Collider2D>(), _circleCollider);
        }
    }

    public enum CellType
    {
        Player,
        Enemy,
        None
    }
}
