using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    private void Start()
    {
        int _levelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        var cell = FindObjectsOfType<Cell>();
        for (int i = 0; i < cell.Length; i++)
        {
            if (cell[i].Type == Cell.CellType.Enemy) return;
        }
        if (Records.Record[_levelNumber].Minute >= (int)Time.timeSinceLevelLoad / 60)
        {
            if (Records.Record[_levelNumber].Second >= (int)Time.timeSinceLevelLoad % 60)
            {
                SaveRecords();
            }
        }
        if (Records.Record[_levelNumber].Second == 0 && Records.Record[_levelNumber].Minute == 0)
            SaveRecords();
    }

    private void SaveRecords()
    {
        int _levelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        PlayerPrefs.SetInt("Level" + _levelNumber + "Second", (int)Time.timeSinceLevelLoad % 60);
        PlayerPrefs.SetInt("Level" + _levelNumber + "Minute", (int)Time.timeSinceLevelLoad / 60);
        PlayerPrefs.Save();
        Records.LoadSetting();
    }
}
