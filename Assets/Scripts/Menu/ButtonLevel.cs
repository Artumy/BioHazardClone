using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonLevel : MonoBehaviour
{
    [SerializeField] private Sprite _closeSprite; 
    [SerializeField] private Sprite _passedSprite; 
    [SerializeField] private Image _image;
    [SerializeField] private int _numberLevel;

    private LevelWindow _levelWindow;
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
        _levelWindow = FindObjectOfType<LevelWindow>();
        var openLevel = PlayerPrefs.GetInt("OpenLevel");
        if (openLevel == 0)
            openLevel = 1;

        var button = GetComponent<Button>();
        SetState(openLevel);
        switch (_state)
        {
            case State.Close:
                _image.sprite = _closeSprite;
                button.onClick.AddListener(_levelWindow.Notify);
                break;
            case State.Open:
                _image.enabled = false;
                button.onClick.AddListener(() => _levelWindow.StartGame(_numberLevel));
                break;
            case State.Passed:
                _image.sprite = _passedSprite;
                button.onClick.AddListener(() => _levelWindow.StartGame(_numberLevel));
                break;
        }
    }    

    private void SetState(int openLevel)
    {
        if (openLevel - _numberLevel >= 1)
            _state = State.Passed;
        else if (openLevel - _numberLevel < 0)
            _state = State.Close;
        else
            _state = State.Open;
    }
}
