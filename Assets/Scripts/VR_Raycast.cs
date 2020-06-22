using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Raycast : MonoBehaviour
{
    RaycastHit _hit;
    VRButton _lastHitButton;
    [SerializeField] GameObject _debugObj;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit))
        {
            VRButton button = _hit.transform.GetComponent<VRButton>();
            _lastHitButton = button;

                    Debug.Log(_hit.collider.gameObject.name);
            if (button != null)
            {
                button.Hover();

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    button.Press();
                }
            }
        }
        else
        {
            if (_lastHitButton != null)
            {
                _lastHitButton.UnHover();
            }
        }
    }
}
