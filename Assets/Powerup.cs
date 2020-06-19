using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Powerup : MonoBehaviour
{
    public enum PowerupType { NONE, SCATTER };

    [SerializeField] Level3Manager _lvl3Man;
    [SerializeField] FPSCrossbow _crossbow;
    [SerializeField] PowerupType _powerup;
    [SerializeField] int _cost;
    [SerializeField] TextMeshProUGUI _costText;

    void Start()
    {
        _costText.text = "$" + _cost;
    }

    public void Purchase()
    {
        if (_lvl3Man.GetCash() >= _cost)
        {
            _lvl3Man.SubtractCash(_cost);
            _crossbow.ActivatePowerup(_powerup);
        }
        else
        {
            Debug.Log("Insufficient funds"); // TODO implement
        }
    }
}
