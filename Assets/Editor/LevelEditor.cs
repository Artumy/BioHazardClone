using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    private List<GameObject> _cells = new List<GameObject>();
    private Level _level;
    private List<bool> _state = new List<bool>();
    private float _speedEntity;
    private float _speedProduction;

    private void Awake()
    {
        _level = (Level)target;
        var cells = FindObjectsOfType<Cell>();        
        foreach (var cell in cells)
        {
            _cells.Add(cell.gameObject);
            _state.Add(false);
        }
    }

    public override void OnInspectorGUI()
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            var name = "Cell " + (i + 1);
            _state[i] = EditorGUILayout.BeginFoldoutHeaderGroup(_state[i], name);
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
                _cells[i].name = name;
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            _speedEntity = EditorGUILayout.Slider("Speed Entity", _speedEntity, 0f, 10f);
            _speedProduction = EditorGUILayout.Slider("Speed Production", _speedProduction, 0f, 10f);
        }

        base.OnInspectorGUI();
        if(GUILayout.Button("Create"))
        {
            _cells.Add(_level.CreateCell());
        }
    }
}
