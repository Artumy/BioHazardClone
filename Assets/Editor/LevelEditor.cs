using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    private List<GameObject> _cells = new List<GameObject>();
    private Level _level;
    private List<bool> _state = new List<bool>();
    private SpeedSetting _setting;
    private int _numberLevel;

    private void Awake()
    {
        _level = (Level)target;
        _numberLevel = _level.NumberLevel;
        var cells = FindObjectsOfType<Cell>();        
        foreach (var cell in cells)
        {
            _cells.Add(cell.gameObject);
            _state.Add(false);
        }

        if(_numberLevel != 0 && LevelSetting.Settings.FindAll(x => x.NumberLevel == _numberLevel).Count == 0)
            LevelSetting.Settings.Add(new SpeedSetting(_numberLevel, 1f, 1f));
    }

    public override void OnInspectorGUI()
    {
        _numberLevel = _level.NumberLevel;
        if (_numberLevel != 0)
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                var name = "Cell " + (i + 1);
                _state[i] = EditorGUILayout.BeginFoldoutHeaderGroup(_state[i], name);
                _cells[i].name = name;
                if (_state[i])
                {
                    _cells[i].transform.position =
                        EditorGUILayout.Vector3Field("Position", _cells[i].transform.position);
                    _cells[i].transform.localScale =
                        EditorGUILayout.Vector3Field("Scale", _cells[i].transform.localScale);
                    var cellScript = _cells[i].GetComponent<Cell>();
                    cellScript.Type = (Cell.CellType)EditorGUILayout.EnumPopup("Type", cellScript.Type);
                    cellScript.MaxCapacity = EditorGUILayout.IntField("Max Capacity", cellScript.MaxCapacity);
                    cellScript.Capacity =
                        EditorGUILayout.IntSlider("Capacity", cellScript.Capacity, 0, cellScript.MaxCapacity);
                    if (GUILayout.Button("Delete Cell"))
                    {
                        DestroyImmediate(_cells[i].gameObject);
                        _cells.RemoveAt(i);
                        _state.RemoveAt(i);
                        return;
                    }
                }

                EditorGUILayout.EndFoldoutHeaderGroup();
            }


            _setting = LevelSetting.Settings[_numberLevel - 1];
            _setting.SpeedEntity = EditorGUILayout.Slider("Speed Entity", _setting.SpeedEntity, 0f, 10f);
            _setting.SpeedProduction = EditorGUILayout.Slider("Speed Production", _setting.SpeedProduction, 0f, 10f);
            LevelSetting.Settings[_numberLevel - 1] = _setting;
            if (GUILayout.Button("Create Cell"))
            {
                _cells.Add(_level.CreateCell());
                _state.Add(false);
            }
        }

        base.OnInspectorGUI();
        if (GUI.changed)
        {
            EditorUtility.SetDirty(_level.gameObject);
            LevelSetting.SaveSetting();
        }
    }

}
