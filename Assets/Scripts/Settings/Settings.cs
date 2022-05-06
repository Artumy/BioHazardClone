using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _easy;
    [SerializeField] private GameObject _middle;
    [SerializeField] private GameObject _difficult;

    private void Start()
    {
        _slider.onValueChanged.AddListener(delegate { ActiveLevelOfDifficult(); });
    }

    private void ActiveLevelOfDifficult()
    {
        _easy.SetActive(false);
        _middle.SetActive(false);
        _difficult.SetActive(false);

        switch (_slider.value)
        {
            case 1:
                _easy.SetActive(true);
                break;
            case 2:
                _middle.SetActive(true);
                break;
            case 3:
                _difficult.SetActive(true);
                break;
        }
        LevelSetting.LevelOfDifficult = (int)_slider.value;
    }
}
