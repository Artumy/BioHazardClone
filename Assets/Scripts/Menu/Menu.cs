using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _exit;
    [SerializeField] private GameObject _notification;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
            OpenExitMenu();
    }
    
    public void StartGame(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void OpenExitMenu()
    {
        _main.SetActive(false);
        _exit.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        PlayerPrefs.DeleteKey("LevelCompleted");
    }

    public void Notify() => _notification.SetActive(!_notification.activeInHierarchy);
}
