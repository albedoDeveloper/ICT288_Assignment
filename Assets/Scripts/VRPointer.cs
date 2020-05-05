/*
 * Author: Robert Valentic
 */

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

    [SerializeField] private horn horn = null;

    private GameObject _heldItem = null;
    private RaycastHit _hit;
    private bool _didHit = false;
    private bool _pickupThisFrame = false;

    private void Update()
    {
        PerformRaycast();
        PickupCoal();
        PullHorn();
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
    }

    private void PickupCoal()
    {
        if (_heldItem == null && _didHit)
        {
            if (_hit.collider.CompareTag("CoalPile") && (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetButtonDown("Fire1")))
            {
                _heldItem = Instantiate(_coalPiecePrefab, _holdPoint, false);
                _pointerBeam.SetActive(false);
                _pickupThisFrame = true;
            }
        }
    }

    private void PullHorn()
    {
        if (_heldItem == null && _didHit)
        {
            if (_hit.collider.CompareTag("Horn") && (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
            {
                horn.hornPosition = 0;
                horn.GetComponent<AudioSource>().Play();
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
