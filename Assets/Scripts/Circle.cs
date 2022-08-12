using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject _circleBehind;

    private GameObject _creatingCircle;
    private GameObject _creatingWood;
    private GameObject _creatingCircleBehind;
    private GameObject _creatingWoodBehind;
    private Vector3 _firstPoint;
    private Vector3 _secondPoint;
    private Vector3 _firstPointBehind;
    private Vector3 _secondPointBehind;

    private CreatingBridge _creatingBridge;

    private void Start()
    {
        int layer_mask = LayerMask.GetMask("Circle");
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10, layer_mask))
        {
            _circleBehind = hit.collider.gameObject;
        }
    }

    private void OnMouseDown()
    {
        if (((int)transform.position.z) != 0) return;

        GameObject creatorController = GameObject.Find("/CreatingBridge");
        _creatingBridge = creatorController.GetComponent<CreatingBridge>();

        _firstPoint = MouseWorldPositionToInt();
        _creatingCircle = _creatingBridge.CreateCircl(_firstPoint);
        _creatingWood = _creatingBridge.CreateWood(_firstPoint);

        _firstPointBehind = _circleBehind.transform.position;
        _creatingCircleBehind = _creatingBridge.CreateCircl(_firstPointBehind);
        _creatingWoodBehind = _creatingBridge.CreateWood(_firstPointBehind);
    }

    private void OnMouseDrag()
    {
        if (((int)transform.position.z) != 0) return;

        _secondPoint = MouseWorldPositionToInt();
        _creatingCircle.transform.position = _secondPoint;
        _creatingWood.GetComponent<Wood>().UpdateCreatingWood(_firstPoint, _secondPoint);

        _secondPointBehind = _secondPoint;
        _secondPointBehind.z = _circleBehind.transform.position.z;
        _creatingCircleBehind.transform.position = _secondPointBehind;
        _creatingWoodBehind.GetComponent<Wood>().UpdateCreatingWood(_firstPointBehind, _secondPointBehind);
    }

    private void OnMouseUp()
    {
        if (((int)transform.position.z) != 0) return;

        _creatingWood.GetComponent<Wood>()._firstFixedJoint.connectedBody = GetComponent<Rigidbody>();
        _creatingWood.GetComponent<Wood>()._secondFixedJoint.connectedBody = _creatingCircle.GetComponent<Rigidbody>();

        _creatingWoodBehind.GetComponent<Wood>()._firstFixedJoint.connectedBody = _circleBehind.GetComponent<Rigidbody>();
        _creatingWoodBehind.GetComponent<Wood>()._secondFixedJoint.connectedBody = _creatingCircleBehind.GetComponent<Rigidbody>();

        CheckAndCreateRoad();
    }

    private void CheckAndCreateRoad()
    {
        if (_firstPoint.y == 0 && _secondPoint.y == 0)
        {
            Vector3 firstRoadPoint = _firstPoint;
            firstRoadPoint.z = (_firstPoint.z + _secondPointBehind.z) / 2;

            Vector3 secondRoadPoint = _secondPoint;
            secondRoadPoint.z = (_firstPoint.z + _secondPointBehind.z) / 2;

            GameObject road = _creatingBridge.CreateRoad(firstRoadPoint);
            road.GetComponent<WoodenRoad>().UpdateCreatingRoad(firstRoadPoint, secondRoadPoint);

            road.GetComponent<WoodenRoad>()._firstFixedJoint.connectedBody = _creatingWood.GetComponent<Rigidbody>();
            road.GetComponent<WoodenRoad>()._secondFixedJoint.connectedBody = _creatingWoodBehind.GetComponent<Rigidbody>();
        }
    }

    private Vector3 MouseWorldPositionToInt()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z -= Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        mousePos3D = Vector3Int.RoundToInt(mousePos3D);
        return mousePos3D;
    }
}
