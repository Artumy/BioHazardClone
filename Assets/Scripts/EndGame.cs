using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameObject _nextLevel;
    [SerializeField] private GameObject _nextLevelBlocked;
    [SerializeField] private Cell[] _cells;
    [SerializeField] private Canvas _canvas;

    private int _savelevelNumber;
    private void Awake()
    {
        _savelevelNumber = PlayerPrefs.GetInt("OpenLevel");
    }
    private void Update()
    {
        CheckCell();
    }

    private void CheckCell()
    {
        var capturedCells = _cells.Where(cell => cell.Type != Cell.CellType.None).ToArray();
        for (int i = 0; i < capturedCells.Length - 1; i++)
        {
            if (capturedCells[i].Type != capturedCells[i + 1].Type)
                return;
        }

        if (capturedCells[0].Type == Cell.CellType.Player)
        {
            _nextLevel.SetActive(true);
            if (_savelevelNumber < SceneManager.GetActiveScene().buildIndex + 1)
                PlayerPrefs.SetInt("OpenLevel", SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
            _nextLevelBlocked.SetActive(true);

        FinishGame();
    }

    private void FinishGame()
    {
        _endMenu.SetActive(true);
        _canvas.sortingOrder = 10;
    }
}
