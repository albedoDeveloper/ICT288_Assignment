using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Powerup : MonoBehaviour
{
    public enum PowerupType { NONE, SCATTER, RAPIDFIRE};

    [SerializeField] Level3Manager _lvl3Man;
    [SerializeField] FPSCrossbow _crossbowPC;
    [SerializeField] FPSCrossbow _crossbowVR;
    [SerializeField] FPSCrossbow _crossbowVRLeft;
    [SerializeField] PowerupType _powerup;
    [SerializeField] int _cost;
    [SerializeField] TextMeshProUGUI _costText;
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _costText.text = "$" + _cost;
    }

    public void Purchase()
    {
        if (_lvl3Man.GetCash() >= _cost)
        {
            _lvl3Man.SubtractCash(_cost);
            if (Application.platform == RuntimePlatform.Android)
            {
                _crossbowVR.ActivatePowerup(_powerup);
                _crossbowVRLeft.ActivatePowerup(_powerup);
            }
            else
            {
                _crossbowPC.ActivatePowerup(_powerup);
            }
        }
        else
        {
            _audioSource.Play();
        }
    }
}
