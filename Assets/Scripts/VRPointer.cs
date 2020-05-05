using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VRPointer : MonoBehaviour
{
    [SerializeField] private GameObject _pointerBeam = null;
    [SerializeField] private float _raycastDistance = 100;
    [SerializeField] private GameObject _coalPiecePrefab = null;
    [SerializeField] private Transform _holdPoint = null;
    [SerializeField] private float _throwForce = 100;
    [SerializeField] private Transform _trainParent = null;

    private GameObject _heldItem = null;
    private RaycastHit _hit;
    private bool _didHit = false;
    private bool _pickupThisFrame = false;

    //added transform variable
    private Transform _testTransform;

    private void Update()
    {
        PerformRaycast();
        PickupCoal();
        if (!_pickupThisFrame)
        {
            ThrowHeldItem();
        }
        _pickupThisFrame = false;
    }

    private void PerformRaycast()
    {
        if (_heldItem == null)
        {
            _didHit = Physics.Raycast(transform.position, transform.forward, out _hit);
        }

        //adding Outline functionality here
        if (_hit.collider.CompareTag("Interactable"))
        {
            _hit.transform.GetComponent<Outline>().enabled = true;
            _testTransform = _hit.transform;
        }
        else
            _testTransform.GetComponent<Outline>().enabled = false;
        /************************************************************************/
    }

    private void PickupCoal()
    {
        if (_heldItem == null && _didHit)
        {
            if (_hit.collider.name == "CoalPile" && (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetButtonDown("Fire1")))
            {
                _heldItem = Instantiate(_coalPiecePrefab, _holdPoint, false);
                _pointerBeam.SetActive(false);
                _pickupThisFrame = true;
            }
        }
    }

    private void ThrowHeldItem()
    {
        if (_heldItem != null)
        {
            if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetButtonDown("Fire1")) && _heldItem.CompareTag("CoalPiece"))
            {
                _heldItem.transform.SetParent(_trainParent);
                Rigidbody rb = _heldItem.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.AddForce(transform.forward * _throwForce, ForceMode.Impulse);
                _heldItem = null;
                _pointerBeam.SetActive(true);
            }
        }
    }
}
