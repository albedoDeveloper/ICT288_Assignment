using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VRPointer : MonoBehaviour
{
    [SerializeField] private GameObject _testCylinder = null;
    [SerializeField] private float _raycastDistance = 100;
    [SerializeField] private GameObject _coalPiecePrefab = null;
    [SerializeField] private Transform _holdPoint = null;
    [SerializeField] private float _throwForce = 100;
    [SerializeField] private TextMeshProUGUI _debugText = null; // FOR TESTING

    private GameObject _heldItem = null;

    private void Update()
    {
        PerformRaycast();
        ThrowCoal();
    }

    private void PerformRaycast()
    {
        RaycastHit hit;
        
        if (_heldItem == null)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                _debugText.text = hit.collider.name; // FOR TESTING

                if (hit.collider.CompareTag("CoalPile") && OVRInput.GetDown(OVRInput.Button.Any) && _heldItem == null)
                {
                    _heldItem = Instantiate(_coalPiecePrefab, _holdPoint, false);
                    _testCylinder.SetActive(false);
                }
            }
        }
    }

    private void ThrowCoal()
    {
        if (OVRInput.GetDown(OVRInput.Button.Any) && _heldItem.CompareTag("CoalPiece"))
        {
            _heldItem.transform.SetParent(null);
            Rigidbody rb = _heldItem.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(transform.forward * _throwForce, ForceMode.Impulse);
            _heldItem = null;
            _testCylinder.SetActive(true);
        }
    }
}
