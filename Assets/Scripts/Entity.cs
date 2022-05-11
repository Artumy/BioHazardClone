using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Entity : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        var numberLevel = FindObjectOfType<Level>().NumberLevel;
        if (numberLevel == gameObject.scene.buildIndex - 1)
            _speed = LevelSetting.Settings[numberLevel].SpeedEntity;
        else
            _speed = LevelSetting.Settings.Find(x => x.NumberLevel == numberLevel).SpeedEntity;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (CompareTag("Player"))
            _spriteRenderer.color = Color.green;
        else
            _spriteRenderer.color = Color.red;
    }

    private void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }
}
