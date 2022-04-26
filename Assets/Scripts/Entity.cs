using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Entity : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _speed = LevelSetting.Settings[SceneManager.GetActiveScene().buildIndex - 1].SpeedEntity;
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
