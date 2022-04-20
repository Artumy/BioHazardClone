using System.Linq;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private Cell[] _cells;
    private void Start()
    {
        InvokeRepeating("CheckCell", 5, 3);
        _cells = FindObjectsOfType<Cell>();
    }

    private void CheckCell()
    {
        var capturedCells = _cells.Where(cell => cell.Type != Cell.CellType.None).ToArray();
        for(int i = 0; i < capturedCells.Length - 1; i++)
        {           
            if(capturedCells[i].Type != capturedCells[i+1].Type)
                return;            
        }

        FinishGame();
    }

    private void FinishGame()
    {
        var levelCompleted = PlayerPrefs.GetInt("LevelCompleted");
        PlayerPrefs.SetInt("LevelCompleted", levelCompleted + 1);
        CancelInvoke();
        Debug.Log("Finish");
    }
}
