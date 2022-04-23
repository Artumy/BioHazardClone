using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _startWindow;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _exit;
    [SerializeField] private GameObject _notification;
    [SerializeField] private GameObject[] _levels;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
            OpenExitMenu();
    }
    
    public void StartGame(int currentLevel)
    {
        //SceneManager.LoadScene(indexScene);
        _levels[currentLevel].SetActive(true);
        _menu.SetActive(false);
    }

    public void OpenExitMenu()
    {
        _startWindow.SetActive(false);
        _exit.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        PlayerPrefs.DeleteKey("LevelCompleted");
    }

    public void Notify() => _notification.SetActive(!_notification.activeInHierarchy);
}
