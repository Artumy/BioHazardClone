using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseWindow : Window
{
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Canvas _canvas;

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            _pauseButton.SetActive(false);
            Time.timeScale = 0;
            _canvas.sortingOrder = 10;
        }
    }

    public override void Initialize()
    {
        _resumeButton.onClick.AddListener(() => ResumeGame());
        _restartButton.onClick.AddListener(() => RestartGame());
        _menuButton.onClick.AddListener(() => OpenMenu());
    }

    private void ResumeGame()
    {
        Hide();
        _pauseButton.SetActive(true);
        Time.timeScale = 1;
        _canvas.sortingOrder = 0;
    }

    private void RestartGame()
    {
        Hide();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OpenMenu()
    {
        Hide();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
