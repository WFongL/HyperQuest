using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCircle : MonoBehaviour
{
    [SerializeField] private FixedJoint _fixedJoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Circle>())
        {
            _fixedJoint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Circle>())
        {
            _fixedJoint.connectedBody = null;
        }
    }
}
