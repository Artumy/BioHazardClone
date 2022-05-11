using UnityEngine;

public class InitialData : MonoBehaviour
{
    private void Awake()
    {
        if(LevelSetting.Settings.Count == 0)
            LevelSetting.LoadSetting();

        if(Records.Record.Count == 0)
            Records.LoadSetting();
    }
}
