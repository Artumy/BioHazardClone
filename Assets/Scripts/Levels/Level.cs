using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCell;
    [SerializeField] private int _numberLevel;

    public int NumberLevel => _numberLevel;

    public GameObject CreateCell()
    {
        return Instantiate(_prefabCell, Vector3.zero, Quaternion.identity);
    }
}
