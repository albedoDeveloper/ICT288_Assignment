/*
 * Author: Robert Valentic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCrossbow : MonoBehaviour
{
    [SerializeField] private GameObject _boltModel = null;
    [SerializeField] private GameObject _projectile = null;
    private bool _reloaded = false;
    private Animator _animator = null;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        TryFire();
    }

    private void TryFire()
    {
        if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0)) && _reloaded)
        {
            Fire();
        }
    }

    private void Fire()
    {
        _boltModel.SetActive(false);
        _animator.SetTrigger("Shoot");
        _reloaded = false;
        LaunchBolt();
    }

    private void LaunchBolt()
    {
        Instantiate(_projectile, _boltModel.transform.position, _boltModel.transform.rotation);
    }

    public void Reload()
    {
        _reloaded = true;
        _boltModel.SetActive(true);
    }
}
