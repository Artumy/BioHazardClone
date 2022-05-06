using UnityEngine;
using TMPro;

public class ShowCellCapacity : MonoBehaviour
{
    [SerializeField] private Cell _cell;

    private TextMeshPro _text;

    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        _text.text = _cell.Capacity.ToString();
    }
}
