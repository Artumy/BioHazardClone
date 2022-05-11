using UnityEngine;
using UnityEngine.UI;

public class ExitWindow : Window
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    public override void Initialize()
    {
        _yesButton.onClick.AddListener(() => Application.Quit());
        _noButton.onClick.AddListener(() => WindowsManager.Show<MenuWindow>());
    }
}
