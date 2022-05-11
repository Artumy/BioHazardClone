using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsWindow : Window
{
    [SerializeField] private Button _backButton;
    [SerializeField] private List<Text> _text = new List<Text>();

    private void Start()
    {
        for (int i = 0; i < _text.Count; i++)
        {
            string second;
            if (Records.Record[i].Second < 10)
                second = "0" + Records.Record[i].Second;
            else
                second = Records.Record[i].Second.ToString();

            _text[i].text = Records.Record[i].Minute + ":" + second;
        }
    }

    public override void Initialize()
    {
        _backButton.onClick.AddListener(() => WindowsManager.Show<MenuWindow>());
    }
}
