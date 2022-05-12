using UnityEngine;
using UnityEngine.UI;

public class RecordsWindow : Window
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Text _text;
    [SerializeField] private Canvas _canvas;

    private const float FrequencyShow = 5;

    private Vector2 _startBestTimeTextPosition;
    private Vector2 _startLevelposition;
    private Vector2 _startBestTimeLevelPosition;

    private void Awake()
    {
        _startBestTimeTextPosition = new Vector2(-400, 50);
        _startLevelposition = new Vector2(-300, 50);
        _startBestTimeLevelPosition = new Vector2(-300, 100);
    }

    private void Start()
    {
        ShowRecordsGrid();
    }

    private void ShowRecordsGrid()
    {
        for (int i = 0, count = 0; i < Mathf.CeilToInt(Records.Record.Count / FrequencyShow); i++)
        {
            // Show best time text
            var level = CreateCanvasObject(_startBestTimeTextPosition);
            level.text = "Лучшее\nвремя";
            _startBestTimeTextPosition -= new Vector2(0, 120);

            for (int j = 0; j < FrequencyShow; j++)
            {
                if (count > Records.Record.Count - 1) return;

                // Show number of level
                level = CreateCanvasObject(_startBestTimeLevelPosition);
                level.text = count + 1 + " уровень";
                _startBestTimeLevelPosition += new Vector2(150, 0);

                // Show best time of level
                var second = "";
                level = CreateCanvasObject(_startLevelposition);
                if (Records.Record[count].Second < 10)
                    second = "0" + Records.Record[count].Second;
                else
                    second = Records.Record[count].Second.ToString();
                level.text = Records.Record[count].Minute + ":" + second;
                _startLevelposition += new Vector2(150, 0);

                count++;
            }
            _startBestTimeLevelPosition += new Vector2(-750, -120);
            _startLevelposition += new Vector2(-750, -120);
        }
    }

    private Text CreateCanvasObject(Vector2 spawnPosition)
    {
        var level = Instantiate(_text, transform.position, Quaternion.identity, gameObject.transform);
        level.GetComponent<RectTransform>().anchoredPosition = spawnPosition;
        return level;
    }

    public override void Initialize()
    {
        _backButton.onClick.AddListener(() => WindowsManager.Show<MenuWindow>());
    }
}
