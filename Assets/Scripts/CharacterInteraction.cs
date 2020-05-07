/*
 * Author: Robert Valentic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private float _raycastDistance = 100;
    [SerializeField] private GameObject _coalPiecePrefab = null;
    [SerializeField] private Transform _holdPoint = null;
    [SerializeField] private float _throwForce = 100;
    [SerializeField] private Transform _trainParent = null;
    [SerializeField] GameObject _crossbowPickup = null;
    [SerializeField] GameObject _fpsCrossbow = null;
    [SerializeField] private horn horn = null;

    [Header("VR Specific")]
    [SerializeField] private GameObject _pointerBeam = null;
    [SerializeField] GameObject _controller = null;

    [Header("PC Specific")]
    [SerializeField] private Transform _pcCamera = null;

    private GameObject _heldItem = null;
    private RaycastHit _hit;
    private bool _didHit = false;
    private bool _pickupThisFrame = false;
    private bool _crossbowEquipped = false;

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
        if ((OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.Space)) && _crossbowEquipped)
        {
            DropCrossbow();
        }
    }

    private void PerformRaycast()
    {
        if (_heldItem == null && _crossbowEquipped == false)
        {
            if (_pcCamera == null)
            {
                _didHit = Physics.Raycast(transform.position, transform.forward, out _hit);

                //Outline code VR
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
            else
            {
                _didHit = Physics.Raycast(_pcCamera.position, _pcCamera.forward, out _hit);
            }
        }
    }

    private void PickupItem()
    {
        if (_heldItem == null && _didHit)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
            {
                if (_hit.collider.name == "CoalPile")
                {
                    _heldItem = Instantiate(_coalPiecePrefab, _holdPoint, false);
                    _pickupThisFrame = true;
                    if (_pointerBeam != null)
                    {
                        _pointerBeam.SetActive(false);
                    }
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
        _crossbowEquipped = false;
        if (_controller != null)
        {
            _controller.SetActive(true);
        }
    }

    private void EquipCrossbow()
    {
        _fpsCrossbow.SetActive(true);
        _crossbowPickup.SetActive(false);
        _crossbowEquipped = true;
        if (_controller != null)
        {
            _controller.SetActive(false);
        }
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
            if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0)) && _heldItem.CompareTag("CoalPiece"))
            {
                _heldItem.transform.SetParent(_trainParent);
                Rigidbody rb = _heldItem.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                if (_pcCamera == null)
                {
                    rb.AddForce(transform.forward * _throwForce, ForceMode.Impulse);
                }
                else
                {
                    rb.AddForce(_pcCamera.forward * _throwForce, ForceMode.Impulse);
                    rb.AddForce(_pcCamera.forward * _throwForce, ForceMode.Impulse);
                }
                _heldItem = null;
                if (_pointerBeam != null)
                {
                    _pointerBeam.SetActive(true);
                }
            }
        }
    }
}
