/*
 * Author: Robert Valentic
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCrossbow : MonoBehaviour
{
    [SerializeField] GameObject _boltModel;
    [SerializeField] GameObject _projectile;
    [SerializeField] GameObject _superProjectile;
    [SerializeField] GameObject _powerupBar;
    bool _reloaded = false;
    Animator _animator = null;
    AudioSource _as;
    Powerup.PowerupType _activePowerup = Powerup.PowerupType.NONE;
    float _powerupTimer;
    GameObject _bolt;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
        _bolt = _projectile;
    }

    public void ActivatePowerup(Powerup.PowerupType type)
    {
        switch (type)
        {
            case Powerup.PowerupType.SCATTER:
                _powerupTimer = 10;
                _activePowerup = Powerup.PowerupType.SCATTER;
                _powerupBar.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Scatter Shot";
                Debug.Log("Scatter shot activated");
                break;
            case Powerup.PowerupType.RAPIDFIRE:
                _powerupTimer = 10;
                _activePowerup = Powerup.PowerupType.RAPIDFIRE;
                _powerupBar.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Rapid Fire";
                _animator.speed = 2;
                break;
        }

        _powerupBar.SetActive(true);
    }

    void Update()
    {
        PowerupCountdown();
        TryFire();
        TickPowerupBar();
    }

    public void ActivateSuperShots()
    {
        _bolt = _superProjectile;
    }

    void TickPowerupBar()
    {
        if (_powerupBar != null)
        {
            _powerupBar.GetComponent<Slider>().value = _powerupTimer;

            if (_powerupTimer <= 0)
            {
                _powerupBar.SetActive(false);
                _animator.speed = 1;
            }
        }
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
    }

    void TryFire()
    {
        if ((OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetMouseButtonDown(0)) && _reloaded)
        {
            switch (_activePowerup)
            {
                case Powerup.PowerupType.SCATTER:
                    FireScatterShot();
                    break;
                case Powerup.PowerupType.RAPIDFIRE:
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
        _boltModel.SetActive(false);
        _animator.SetTrigger("Shoot");
        _reloaded = false;
        LaunchTripleBolt();
        _as.Play();
    }

    void LaunchTripleBolt()
    {
        const float ANGLE = 5;

        Instantiate(_bolt, _boltModel.transform.position, _boltModel.transform.rotation);
        GameObject left = Instantiate(_bolt, _boltModel.transform.position, _boltModel.transform.rotation);
        GameObject right = Instantiate(_bolt, _boltModel.transform.position, _boltModel.transform.rotation);
        left.transform.Rotate(left.transform.up, ANGLE, Space.World);
        right.transform.Rotate(right.transform.up, -ANGLE, Space.World);
    }

    void LaunchBolt()
    {
        Instantiate(_bolt, _boltModel.transform.position, _boltModel.transform.rotation);
    }

    public void Reload()
    {
        _reloaded = true;
        _boltModel.SetActive(true);
    }
}
