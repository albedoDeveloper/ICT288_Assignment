using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCamera : MonoBehaviour
{
    [SerializeField] float _speed = 30;
    [SerializeField] float _mouseSense = 30;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * Input.GetAxis("Vertical") * _speed, Space.World);
        transform.Translate(transform.right * Time.deltaTime * Input.GetAxis("Horizontal") * _speed, Space.World);
        transform.Rotate(transform.right, Input.GetAxis("Mouse Y") * Time.deltaTime * -_mouseSense);
        transform.Rotate(transform.up, Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSense);
    }
}
