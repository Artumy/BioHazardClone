using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelWindow : Window
{
    [SerializeField] private Button _backButton;
    [SerializeField] private GameObject _notification;

    public override void Initialize()
    {
        _backButton.onClick.AddListener(() => WindowsManager.Show<MenuWindow>());
    }

    public void StartGame(int indexScene) => SceneManager.LoadScene(indexScene);

    public void Notify() => _notification.SetActive(!_notification.activeInHierarchy);
}
