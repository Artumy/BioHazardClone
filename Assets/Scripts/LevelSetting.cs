using System.Collections.Generic;
using System.IO;

public static class LevelSetting
{
    public static List<PairSpeed> Settings = new List<PairSpeed>();

    static LevelSetting()
    {
        LoadSetting();
    }

    public static void LoadSetting()
    {
        using (var reader = new StreamReader("LevelSetting.bin"))
        {
            while (!reader.EndOfStream)
            {
                var values = reader.ReadLine().Split(' ');
                Settings.Add(new PairSpeed(float.Parse(values[0]), float.Parse(values[1])));
            }
        }
    }

    public static void SaveSetting()
    {
        using (var writer = new StreamWriter(File.Open("LevelSetting.bin", FileMode.Create)))
        {
            foreach (var setting in Settings)
                writer.WriteLine(setting.SpeedEntity + " " + setting.SpeedProduction);
        }
    }
}

