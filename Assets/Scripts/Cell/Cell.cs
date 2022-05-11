using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Cell : MonoBehaviour
{
    [SerializeField] private CellType _type;
    [SerializeField] private int _capacity;
    [SerializeField] private int _maxCapacity;
    [SerializeField] private float _speedProduction = 1f;
    [SerializeField] private GameObject _prefabEntity;

    [SerializeField] private Color _playerColor;
    [SerializeField] private Color _enemyColor;
    [SerializeField] private Color _noneColor;

    private const float CoefficientOfDifficult = 0.01f;
    private SpriteRenderer _spriteRenderer;
    private float _radius;
    private float _currentTime;
    private int _numberLevel;

    public enum CellType
    {
        Player,
        Enemy,
        None
    }

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

    public int MaxCapacity
    {
        get => _maxCapacity;
        set => _maxCapacity = value;
    }

    public CellType Type
    {
        get => _type;
        set => _type = value;
    }

    private void Awake()
    {
        _numberLevel = FindObjectOfType<Level>().NumberLevel;
        if (_numberLevel == gameObject.scene.buildIndex - 1)
            _speedProduction = LevelSetting.Settings[_numberLevel].SpeedProduction;
        else
        {
            _speedProduction = LevelSetting.Settings.Find(x => x.NumberLevel == _numberLevel).SpeedProduction;
        }

        _currentTime = _speedProduction;
        _radius = GetComponent<CircleCollider2D>().radius;
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        SetColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_capacity == 0)
        {
            if (collision.CompareTag("Player"))
                _type = CellType.Player;
            else
                _type = CellType.Enemy;

            _capacity += 1;
            Destroy(collision.gameObject);
            SetColor();
            return;
        }

        if (collision.CompareTag(_type.ToString()))
            _capacity += 1;
        else
            _capacity -= 1;

        if (_capacity == 0)
            _type = CellType.None;

        SetColor();
        Destroy(collision.gameObject);
    }

    private void Update()
    {
        if (_type != CellType.None)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                ProduceEntity();
                _currentTime = _speedProduction;
            }
        }
    }

    private void SetColor()
    {
        if (_type == CellType.None)
        {
            _spriteRenderer.color = _noneColor;
            _speedProduction = LevelSetting.Settings[_numberLevel].SpeedProduction;
        }
        else if (_type == CellType.Player)
        {
            _spriteRenderer.color = _playerColor;
            _speedProduction = LevelSetting.Settings[_numberLevel].SpeedProduction;
        }
        else
        {
            _spriteRenderer.color = _enemyColor;
            SetDifficulty();
        }
    }

    private void SetDifficulty()
    {
        _speedProduction = LevelSetting.Settings[_numberLevel].SpeedProduction - LevelSetting.LevelOfDifficult * CoefficientOfDifficult;
    }

    private void ProduceEntity() => Capacity++;

    private List<RaycastHit2D> GetHits(Vector3 point)
    {
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        RaycastHit2D[] hit;
        Vector2 startRayPosition = transform.position;
        var directionRay = (Vector2)(point - transform.position);

        // Set correct directionRay and add colliders from center cell to point
        startRayPosition = transform.position;
        hit = Physics2D.RaycastAll(startRayPosition, directionRay, directionRay.magnitude);
        for (int i = 0; i < hit.Length; i++)
            hits.Add(hit[i]);

        directionRay = (Vector2)(hit[hit.Length - 1].transform.position - transform.position);

        // Set the target collider
        RaycastHit2D target = hit[hit.Length - 1];

        // Set colliders from two borders of the circle
        if ((directionRay.x < 0 && directionRay.y < 0) || (directionRay.x > 0 && directionRay.y > 0))
        {
            hit = GetRayColliders(startRayPosition.x - _radius, startRayPosition.y + _radius, directionRay);
            for (int i = 0; i < hit.Length; i++)
                hits.Add(hit[i]);

            hit = GetRayColliders(startRayPosition.x + _radius, startRayPosition.y - _radius, directionRay);
            for (int i = 0; i < hit.Length; i++)
                hits.Add(hit[i]);
        }
        else
        {
            hit = GetRayColliders(startRayPosition.x - _radius, startRayPosition.y - _radius, directionRay);
            for (int i = 0; i < hit.Length; i++)
                hits.Add(hit[i]);

            hit = GetRayColliders(startRayPosition.x + _radius, startRayPosition.y + _radius, directionRay);
            for (int i = 0; i < hit.Length; i++)
                hits.Add(hit[i]);
        }

        // Delete duplicate the target from main array
        for (int i = 0; i < hits.Count; i++)
        {
            if (hits[i].transform.name == target.transform.name)
            {
                hits.RemoveAt(i);
                i--;
            }
        }

        // Add target in the main 
        hits.Add(target);

        return hits;
    }

    private RaycastHit2D[] GetRayColliders(float startX, float startY, Vector2 direction)
    {
        Vector2 start = new Vector2(startX, startY);
        return Physics2D.RaycastAll(start, direction, direction.magnitude);
    }

    public void SpawnEntity(Vector3 point)
    {
        var hits = GetHits(point);
        if (hits.Count > 1)
        {
            var count = _capacity / 2;
            _capacity -= count;
            var direction = (hits[hits.Count - 1].transform.position - transform.position);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            for (int i = 0; i < count; i++)
            {
                var offset = new Vector3(Random.Range(-_radius, _radius), Random.Range(-_radius, _radius), 0f);
                var entity = Instantiate(_prefabEntity, transform.position + offset, Quaternion.identity);
                entity.tag = _type.ToString();
                entity.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                var entityCollider = entity.GetComponent<Collider2D>();
                for (int j = 0; j < hits.Count - 1; j++)
                    Physics2D.IgnoreCollision(entityCollider, hits[j].collider);
            }
        }
    }
}
