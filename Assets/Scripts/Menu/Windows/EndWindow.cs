using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndWindow : Window
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;

    public override void Initialize()
    {
        _nextButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        _restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        _menuButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }
}
