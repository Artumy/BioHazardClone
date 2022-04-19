using System.Linq;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("CheckCell", 5, 3);
    }

    private void CheckCell()
    {
        var cells = FindObjectsOfType<Cell>().Where(cell => cell.Type != Cell.CellType.None).ToArray();
        for(int i = 0; i < cells.Length - 1; i++)
        {           
            if(cells[i].Type != cells[i+1].Type)
                return;            
        }

        FinishGame();
    }

    private void FinishGame()
    {
        Debug.Log("Finish");
    }
}
