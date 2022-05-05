using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Records
{
    public static List<RecordSettings> Record = new List<RecordSettings>();


    public static void LoadSetting()
    {
        Record.Clear();
        for (int i = 0; i < LevelSetting.Settings.Count; i++)
        {
            Record.Add(new RecordSettings(PlayerPrefs.GetInt("Level" + i + "Minute"), PlayerPrefs.GetInt("Level" + i + "Second")));
        }
    }
}

