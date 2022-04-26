using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class LevelSettingWindow : EditorWindow
{
    private float _speedEntity;
    private float _speedProduction;
    private List<PairSpeed> _settings = new List<PairSpeed>();

    [MenuItem("Window/LevelSetting")]
    private static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(LevelSettingWindow));
    }

    private void Awake()
    {
        _settings = LevelSetting.Settings;
    }

    private void OnGUI()
    {
        using (var reader = new StreamReader("LevelSetting.bin"))
        {
            for(int i = 0; i < _settings.Count; i++)
            { 
                GUILayout.Label("Level " + (i + 1), EditorStyles.boldLabel);
                _speedEntity = EditorGUILayout.Slider("Entity Speed", _settings[i].SpeedEntity, 0, 10);
                _speedProduction = EditorGUILayout.Slider("Production Speed", _settings[i].SpeedProduction, 0, 10);
                _settings[i] = new PairSpeed(_speedEntity,_speedProduction);
            }            
        }
    }

    private void OnDestroy()
    {
        LevelSetting.SaveSetting();
    }
}
