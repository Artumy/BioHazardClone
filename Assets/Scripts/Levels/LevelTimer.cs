using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private List<Cell> _cells = new List<Cell>();
    private void Start()
    {
        var levelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        for (int i = 0; i < _cells.Count; i++)
        {
            if (_cells[i].Type == Cell.CellType.Enemy) return;
        }

        if (Records.Record[levelNumber].Minute >= (int)Time.timeSinceLevelLoad / 60)
        {
            if (Records.Record[levelNumber].Second >= (int)Time.timeSinceLevelLoad % 60)
            {
                SaveRecords(levelNumber);
            }
        }

        if (Records.Record[levelNumber].Second == 0 && Records.Record[levelNumber].Minute == 0)
            SaveRecords(levelNumber);
    }

    private void SaveRecords(int level)
    {
        PlayerPrefs.SetInt("Level" + level + "Second", (int)Time.timeSinceLevelLoad % 60);
        PlayerPrefs.SetInt("Level" + level + "Minute", (int)Time.timeSinceLevelLoad / 60);
        PlayerPrefs.Save();
        Records.LoadSetting();
    }
}
