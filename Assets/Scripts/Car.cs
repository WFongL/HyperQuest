using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private CreatingBridge _creatingBridge;
    public float _speed = 1;
    private bool _go = false;

    private void OnMouseDown()
    {
        _go = true;
        _creatingBridge.OffKinematic();
    }

    private void FixedUpdate()
    {
        if (_go)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
    }
}
