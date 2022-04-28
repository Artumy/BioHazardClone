using System.Collections.Generic;
using System.IO;

public static class LevelSetting
{
    public static List<SpeedSetting> Settings = new List<SpeedSetting>();

    static LevelSetting()
    {
        LoadSetting();
    }

    public static void LoadSetting()
    {
        using (var reader = new StreamReader("Assets/LevelSetting.bin"))
        {
            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(' ');
                Settings.Add(new SpeedSetting(int.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2])));
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

