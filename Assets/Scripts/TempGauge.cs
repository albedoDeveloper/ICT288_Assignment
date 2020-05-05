/*
 * Author: Robert Valentic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempGauge : MonoBehaviour
{
    [SerializeField] private GameObject _pointer = null;
    [SerializeField] float _coldRotation;
    [SerializeField] float _hotRotation;

    public void UpdatePointer(float lerpValue)
    {
        float xRot = _pointer.transform.rotation.x;
        float yRot = Mathf.Lerp(_coldRotation, _hotRotation, lerpValue);
        float zRot = _pointer.transform.rotation.z;
        _pointer.transform.localEulerAngles = new Vector3(xRot, yRot, zRot);
    }
}
