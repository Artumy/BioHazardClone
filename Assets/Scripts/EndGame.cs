using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endMenu;

    private Cell[] _cells;
    private Canvas _canvas;
    private void Start()
    {
        InvokeRepeating("CheckCell", 5f, 3f);
        _cells = FindObjectsOfType<Cell>();
        _canvas = FindObjectOfType<Canvas>();
    }

    private void CheckCell()
    {
        var capturedCells = _cells.Where(cell => cell.Type != Cell.CellType.None).ToArray();
        for (int i = 0; i < capturedCells.Length - 1; i++)
        {
            if (capturedCells[i].Type != capturedCells[i + 1].Type)
                return;
        }

        FinishGame();
    }

    private void FinishGame()
    {
        PlayerPrefs.SetInt("OpenLevel", SceneManager.GetActiveScene().buildIndex + 1);
        CancelInvoke();
        _endMenu.SetActive(true);
        _canvas.sortingOrder = 10;
    }
}
