using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    private void Start()
    {
        int levelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        var cell = FindObjectsOfType<Cell>();
        for (int i = 0; i < cell.Length; i++)
        {
            if (cell[i].Type == Cell.CellType.Enemy) return;
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
