using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class LevelSetting
{
    public static List<SpeedSetting> Settings = new List<SpeedSetting>();
    public static int LevelOfDifficult;

    public static void LoadSetting()
    {
        TextAsset data = Resources.Load("LevelSetting") as TextAsset;
        var values = data.text.Split(new char[] { ' ', '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < values.Length / 3; i++)
        {
            int.TryParse(values[3 * i], out int value);
            float.TryParse(values[3 * i + 1], out float value2);
            float.TryParse(values[3 * i + 2], out float value3);
            Settings.Add(new SpeedSetting(value, value2, value3));
        }
    }

    public static void SaveSetting()
    {
        using (var writer = new StreamWriter(File.Open("Assets/Resources/LevelSetting.txt", FileMode.Create)))
        {
            foreach (var setting in Settings)
                writer.WriteLine(setting.NumberLevel + " " + setting.SpeedEntity + " " + setting.SpeedProduction);
        }
    }
}

