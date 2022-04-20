using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonLevel : MonoBehaviour
{
    [SerializeField] private Sprite _closeSprite; 
    [SerializeField] private Sprite _passedSprite; 
    [SerializeField] private Image _image;
    [SerializeField] private int _numberLevel;

    private Menu _menu;
    private State _state;

    public enum State
    {
        None,
        Close,
        Open,
        Passed
    }

    private void Awake()
    {
        _menu = GameObject.Find("Canvas").GetComponent<Menu>();
        var levelCompleted = PlayerPrefs.GetInt("LevelCompleted");
        var button = GetComponent<Button>();
        SetState(levelCompleted);
        switch (_state)
        {
            case State.Close:
                _image.sprite = _closeSprite;
                button.onClick.AddListener(_menu.Notify);
                break;
            case State.Open:
                _image.enabled = false;
                button.onClick.AddListener(() => _menu.StartGame(_numberLevel));
                break;
            case State.Passed:
                _image.sprite = _passedSprite;
                button.onClick.AddListener(() => _menu.StartGame(_numberLevel));
                break;
        }
    }    

    private void SetState(int levelCompleted)
    {
        levelCompleted += 1;

        if (levelCompleted - _numberLevel > 0)
            _state = State.Passed;
        else if (levelCompleted - _numberLevel < 0)
            _state = State.Close;
        else
            _state = State.Open;
    }
}
