using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenRoad : MonoBehaviour
{
    public FixedJoint _firstFixedJoint;
    public FixedJoint _secondFixedJoint;

    public void UpdateCreatingRoad(Vector3 firstPointRoad, Vector3 secondPointRoad)
    {
        transform.LookAt(secondPointRoad);
        Vector3 dir = secondPointRoad - firstPointRoad;
        float length = dir.magnitude;
        transform.localScale = new Vector3(1, 1, length);
    }
}
