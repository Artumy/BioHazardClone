using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Level" + (SceneManager.GetActiveScene().buildIndex - 1) + "Second", (int)Time.timeSinceLevelLoad % 60);
        PlayerPrefs.SetInt("Level" + (SceneManager.GetActiveScene().buildIndex - 1) + "Minute", (int)Time.timeSinceLevelLoad / 60);
        PlayerPrefs.Save();
        Records.LoadSetting();
    }
}
