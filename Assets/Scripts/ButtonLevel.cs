using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    [SerializeField] private State _state;
    [SerializeField] private Sprite _closeSprite; 
    [SerializeField] private Sprite _passedSprite; 
    [SerializeField] private Image _image;

    private Menu _menu;

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
    }

    private void Start()
    {
        switch(_state)
        {
            case State.Close:
                _image.sprite = _closeSprite;
                var button = GetComponent<Button>();
                button.onClick.AddListener(_menu.Notify);
                break;
            case State.Open:
                _image.enabled = false;
                break;
            case State.Passed:
                _image.sprite = _passedSprite;
                break;
        }
    }

    
}
