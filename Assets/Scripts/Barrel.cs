using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    GameObject _mesh = null;
    Rigidbody _rb = null;

    // Start is called before the first frame update
    void Start()
    {
        _mesh = transform.Find("Mesh").gameObject;
        _rb = GetComponent<Rigidbody>();
        PushForward(500);
    }

    void PushForward(float force)
    {
        _rb.AddForce(transform.forward * Time.deltaTime * force, ForceMode.Impulse);
    }
}
