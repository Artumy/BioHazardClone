using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private GameObject _pauseButton;

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
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void OpenMainMenu()
    {
        EditorSceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
