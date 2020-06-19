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
    bool _reloaded = false;
    Animator _animator = null;
    AudioSource _as;
    Powerup.PowerupType _activePowerup = Powerup.PowerupType.NONE;
    float _powerupTimer;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
    }

    public void ActivatePowerup(Powerup.PowerupType type)
    {
        switch (type)
        {
            case Powerup.PowerupType.SCATTER:
                _powerupTimer = 10;
                _activePowerup = Powerup.PowerupType.SCATTER;
                Debug.Log("Scatter shot activated");
                break;
        }
    }

    void Update()
    {
        PowerupCountdown();
        TryFire();
    }

    void PowerupCountdown()
    {
        if (_activePowerup != Powerup.PowerupType.NONE)
        {
            _powerupTimer -= 1 * Time.deltaTime;
            if (_powerupTimer <= 0)
            {
                _powerupTimer = 0;
                _activePowerup = Powerup.PowerupType.NONE;
            }
        }

        //Debug.Log("Powerup time left: " + _powerupTimer);
    }

    void TryFire()
    {
        if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0)) && _reloaded)
        {
            switch (_activePowerup)
            {
                case Powerup.PowerupType.SCATTER:
                    FireScatterShot();
                    break;
                case Powerup.PowerupType.NONE:
                    FireNormalShot();
                    break;
            }
        }
    }

    void FireNormalShot()
    {
        _boltModel.SetActive(false);
        _animator.SetTrigger("Shoot");
        _reloaded = false;
        LaunchBolt();
        _as.Play();
    }

    void FireScatterShot()
    {
        Debug.Log("Scatter shot fired");
    }

    void LaunchBolt()
    {
        Instantiate(_projectile, _boltModel.transform.position, _boltModel.transform.rotation);
    }

    public void Reload()
    {
        _reloaded = true;
        _boltModel.SetActive(true);
    }
}
