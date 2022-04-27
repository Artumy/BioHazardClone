using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCell;

    private List<GameObject> _cells = new List<GameObject>();

    public GameObject CreateCell()
    {
        return Instantiate(_prefabCell, Vector3.zero, Quaternion.identity);
    }
}
