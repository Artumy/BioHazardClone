using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Entity : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private SpriteRenderer _spriteRenderer;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (gameObject.tag == "Player")
            _spriteRenderer.color = Color.green;
        else
            _spriteRenderer.color = Color.red;
    }

    private void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }
}