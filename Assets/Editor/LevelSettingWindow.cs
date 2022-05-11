using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelSettingWindow : EditorWindow
{
    private float _speedEntity;
    private float _speedProduction;
    private List<SpeedSetting> _settings = new List<SpeedSetting>();

    private void Awake()
    {
        _settings = LevelSetting.Settings;
    }

    private void OnGUI()
    {
        if(_settings.Count == 0)
            LevelSetting.LoadSetting();

        for(int i = 0; i < _settings.Count; i++)
        { 
            GUILayout.Label("Level " + (_settings[i].NumberLevel), EditorStyles.boldLabel);
            _speedEntity = EditorGUILayout.Slider("Entity Speed", _settings[i].SpeedEntity, 0, 10);
            _speedProduction = EditorGUILayout.Slider("Production Speed", _settings[i].SpeedProduction, 0, 10);
            _settings[i] = new SpeedSetting(_settings[i].NumberLevel, _speedEntity,_speedProduction);
        }            
    }

    private void OnLostFocus()
    {
        LevelSetting.SaveSetting();
    }

    [MenuItem("Window/LevelSetting")]
    private static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(LevelSettingWindow));
    }

}
