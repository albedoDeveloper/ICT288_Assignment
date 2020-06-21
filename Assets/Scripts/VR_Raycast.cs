using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Raycast : MonoBehaviour
{
    RaycastHit _hit;
    VRButton _lastHitButton;
    [SerializeField] GameObject _hitImage;

    private void Start()
    {
        _hitImage = Instantiate(_hitImage, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit))
        {
            VRButton button = _hit.transform.GetComponent<VRButton>();
            _lastHitButton = button;

            //if (_hitImage != null)
            //{
            //    _hitImage.SetActive(true);
            //    _hitImage.transform.LookAt(transform);
            //    _hitImage.transform.position = _hit.point;
            //}

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

            //if (_hitImage != null)
            //{
            //    _hitImage.SetActive(false);
            //}
        }
    }
}
