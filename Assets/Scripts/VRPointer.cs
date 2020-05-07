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
    [SerializeField] GameObject _crossbowPickup = null;
    [SerializeField] GameObject _controller = null;
    [SerializeField] GameObject _fpsCrossbow = null;
    [SerializeField] private horn horn = null;

    private GameObject _heldItem = null;
    private RaycastHit _hit;
    private bool _didHit = false;
    private bool _pickupThisFrame = false;
    private bool _crossbowEquipped = false;
    private Transform _testTransform;

    private Outline _previousOutline;

    private void Update()
    {
        PerformRaycast();
        PickupItem();
        PullHorn();
        DropItem();
        if (!_pickupThisFrame)
        {
            ThrowHeldItem();
        }
        _pickupThisFrame = false;
    }

    private void DropItem()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) && _crossbowEquipped)
        {
            DropCrossbow();
        }
    }

    private void PerformRaycast()
    {
        if (_heldItem == null && _crossbowEquipped == false)
        {
            _didHit = Physics.Raycast(transform.position, transform.forward, out _hit);
        }

        //if pointer hit a collider
        if (_didHit)
        {
            //if collider obj has outline script
            if (_hit.collider.GetComponent<Outline>() != null)
            {
                //if obj is Horn 
                if (_hit.collider.CompareTag("Horn"))
                {
                    _hit.collider.GetComponent<Outline>().enabled = true;
                    _previousOutline = _hit.collider.GetComponent<Outline>();
                }
                //if obj is CoalPile 
                if (_hit.collider.CompareTag("CoalPile"))
                {
                    _hit.collider.GetComponent<Outline>().enabled = true;
                    _previousOutline = _hit.collider.GetComponent<Outline>();
                }
                //if obj is Crossbow
                if (_hit.collider.CompareTag("Crossbow"))
                {
                    _hit.collider.GetComponent<Outline>().enabled = true;
                    _previousOutline = _hit.collider.GetComponent<Outline>();
                }
            }
            else
                if (_previousOutline != null)
            {
                _previousOutline.enabled = false;
            }

        }
        else
            if (_previousOutline != null)
        {
            _previousOutline.enabled = false;
        }//end of Raycast Outline code
    }

    private void PickupItem()
    {
        if (_heldItem == null && _didHit)
        {
            if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
            {
                if (_hit.collider.name == "CoalPile")
                {
                    _heldItem = Instantiate(_coalPiecePrefab, _holdPoint, false);
                    _pointerBeam.SetActive(false);
                    _pickupThisFrame = true;
                }
                else if (_hit.collider.name == "CrossbowPickup")
                {
                    EquipCrossbow();
                }
            }
        }
    }

    private void DropCrossbow()
    {
        _fpsCrossbow.SetActive(false);
        _crossbowPickup.SetActive(true);
        _controller.SetActive(true);
        _crossbowEquipped = false;
    }

    private void EquipCrossbow()
    {
        _fpsCrossbow.SetActive(true);
        _crossbowPickup.SetActive(false);
        _controller.SetActive(false);
        _crossbowEquipped = true;
    }

    private void PullHorn()
    {
        if (_heldItem == null && _didHit)
        {
            if (_hit.collider.CompareTag("Horn") && (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)))
            {
                horn.hornPosition = 1;
                horn.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void ThrowHeldItem()
    {
        if (_heldItem != null)
        {
            if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) && _heldItem.CompareTag("CoalPiece"))
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
