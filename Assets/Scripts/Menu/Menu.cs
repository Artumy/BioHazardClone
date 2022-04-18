using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _level;
    [SerializeField] private GameObject _exit;
    [SerializeField] private GameObject _notification;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
            OpenExitMenu();
    }

    public void OpenLevelMenu()
    {
        _main.SetActive(false);
        _level.SetActive(true);
    }

    public void OpenMainMenu()
    {
        _main.SetActive(true);
        _level.SetActive(false);
    }
    
    public void OpenExitMenu()
    {
        _main.SetActive(false);
        _exit.SetActive(true);
    }

    public void CloseExitMenu()
    {
        _main.SetActive(true);
        _exit.SetActive(false);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void Notify() => _notification.SetActive(!_notification.activeInHierarchy);
}
