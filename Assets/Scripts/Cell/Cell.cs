using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Cell : MonoBehaviour
{
    [SerializeField] private CellType _type;
    [SerializeField] private int _capacity;
    [SerializeField] private int _maxCapacity;
    [SerializeField] private float _repeatTime = 1f;
    [SerializeField] private GameObject _prefabEntity;

    private SpriteRenderer _spriteRenderer;
    private float _radius;
    private float _currentTime;


    public CellType Type => _type;

    public int Capacity
    {
        get => _capacity;
        set
        {
            if (value >= _maxCapacity)
                _capacity = _maxCapacity;
            else
                _capacity = value;
        }
    }


    private void Awake()
    {
        _currentTime = _repeatTime;
        _radius = GetComponent<CircleCollider2D>().radius;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetColor();
    }

    private void Update()
    {
        if (_type != CellType.None)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                ProduceEntity();
                _currentTime = _repeatTime;
            }
        }
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

    private void ProduceEntity() => Capacity++;

    private RaycastHit2D[] GetHits()
    {
        var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var directionRay = (Vector2)(point - transform.position);
        return Physics2D.RaycastAll(transform.position, directionRay, directionRay.magnitude);
    }

    public void SpawnEntity()
    {
        var hits = GetHits();
        if (hits.Length > 1)
        {
            var count = _capacity / 2;
            _capacity -= count;
            var direction = (hits[hits.Length - 1].transform.position - transform.position);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            for (int i = 0; i < count; i++)
            {
                var offset = new Vector3(Random.Range(-_radius, _radius), Random.Range(-_radius, _radius), 0f);
                var entity = Instantiate(_prefabEntity, transform.position + offset, Quaternion.identity);
                entity.tag = _type.ToString();
                entity.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                var entityCollider = entity.GetComponent<Collider2D>();
                for (int j = 0; j < hits.Length - 1; j++)
                    Physics2D.IgnoreCollision(entityCollider, hits[j].collider);
            }
        }
    }

    public enum CellType
    {
        Player,
        Enemy,
        None
    }
}
