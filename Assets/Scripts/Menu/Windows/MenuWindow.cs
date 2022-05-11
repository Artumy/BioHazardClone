using UnityEngine;
using UnityEngine.UI;

public class MenuWindow : Window
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingButton;
    [SerializeField] private Button _recordsButton;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            WindowsManager.Show<ExitWindow>();
    }

    public override void Initialize()
    {
        _playButton.onClick.AddListener(() => WindowsManager.Show<LevelWindow>());
        _settingButton.onClick.AddListener(() => WindowsManager.Show<SettingsWindow>());
        _recordsButton.onClick.AddListener(() => WindowsManager.Show<RecordsWindow>());
    }
}
