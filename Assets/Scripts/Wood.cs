using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public FixedJoint _firstFixedJoint;
    public FixedJoint _secondFixedJoint;

    public void UpdateCreatingWood(Vector3 firstPointWood, Vector3 secondPointWood)
    {
        transform.LookAt(secondPointWood);
        Vector3 dir = secondPointWood - firstPointWood;
        float length = dir.magnitude;
        transform.localScale = new Vector3(1, 1, length);
    }
}
