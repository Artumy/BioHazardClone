using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _nextLevelButton;

    public void Start()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        if (index == SceneManager.sceneCount - 1)
            _nextLevelButton.SetActive(false);
    }

    public void ResumeGame()
    {
        _pauseWindow.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        _pauseWindow.SetActive(true);
        _pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
