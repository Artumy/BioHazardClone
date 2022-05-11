using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] private Window _startingWindow;
    [SerializeField] private Window[] windows;

    private static WindowsManager _instance;

    private Window _currentWindow;

    private void Awake()
    {
        if( _instance == null)
            _instance = this;
    }

    private void Start()
    {
        foreach(var window in windows)
        {
            window.Initialize();
            window.Hide();
        }

        if (_startingWindow != null)
        {
            _startingWindow.Show();
            _currentWindow = _startingWindow;
        }
    }

    public static void Show<T>()where T: Window
    {
        foreach(var window in _instance.windows)
        {
            if(window is T)
            {
                if(_instance._currentWindow != null)
                    _instance._currentWindow.Hide();

                window.Show();
                _instance._currentWindow = window;
            }            
        }
    }
}
