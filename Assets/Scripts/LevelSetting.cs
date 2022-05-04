using System.Collections.Generic;
using System.IO;

public static class LevelSetting
{
    public static List<SpeedSetting> Settings = new List<SpeedSetting>();

    public static void LoadSetting()
    {
        using (var reader = new StreamReader("Assets/LevelSetting.bin"))
        {
            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(' ');
                int.TryParse(values[0], out int value);
                float.TryParse(values[1], out float value2);
                float.TryParse(values[2], out float value3);
                Settings.Add(new SpeedSetting(value, value2, value3));
            }
        }
    }

    public static void SaveSetting()
    {
        using (var writer = new StreamWriter(File.Open("Assets/LevelSetting.bin", FileMode.Create)))
        {
            foreach (var setting in Settings)
                writer.WriteLine(setting.NumberLevel + " " + setting.SpeedEntity + " " + setting.SpeedProduction);
        }
    }
}

