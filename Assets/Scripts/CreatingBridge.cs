using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingBridge : MonoBehaviour
{
    [SerializeField] private GameObject _circlePrefab;
    [SerializeField] private GameObject _woodPrefab;
    [SerializeField] private GameObject _roadPrefab;
    private GameObject _circl;
    private GameObject _wood;
    private GameObject _road;
    private Quaternion turn = Quaternion.Euler(0, 90, 0);
    private List<GameObject> _bridgeElement = new List<GameObject>();

    public GameObject CreateCircl(Vector3 firstPoint)
    {
        _circl = Instantiate(_circlePrefab, firstPoint, turn, transform);
        _bridgeElement.Add(_circl);
        return _circl;
    }

    public GameObject CreateWood(Vector3 firstPoint)
    {
        _wood = Instantiate(_woodPrefab, firstPoint, turn, transform);
        _bridgeElement.Add(_wood);
        return _wood;
    }
    public GameObject CreateRoad(Vector3 firstPoint)
    {
        _road = Instantiate(_roadPrefab, firstPoint, turn, transform);
        _bridgeElement.Add(_road);
        return _road;
    }

    public void OffKinematic()
    {
        for (int i = 0; i < _bridgeElement.Count; i++)
        {
            _bridgeElement[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
