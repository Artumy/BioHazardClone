using System.Linq;
using UnityEngine;

public class ArtificialIntelligence : MonoBehaviour
{
    [SerializeField] private float _time;

    private float _currentTime = 0f;

    private void Update()
    {
        if(_currentTime <= 0)
        {
            var cells = FindObjectsOfType<Cell>();
            var enemyCells = cells.Where(cell => cell.Type == Cell.CellType.Enemy).ToArray();
            var otherCells = cells.Where(cell => cell.Type != Cell.CellType.Enemy).ToArray();
            if (enemyCells.Length == 0 || otherCells.Length == 0)
                return;

            var indexEnemyCells = Random.Range(0, enemyCells.Length);
            var indexOtherCells = Random.Range(0, otherCells.Length);
            enemyCells[indexEnemyCells].SpawnEntity(otherCells[indexOtherCells].transform.position);
            _currentTime = _time;
        }

        _currentTime -= Time.deltaTime;
    }
}
