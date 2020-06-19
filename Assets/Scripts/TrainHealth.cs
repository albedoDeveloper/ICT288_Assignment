using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainHealth : MonoBehaviour
{
    short _healthPoints = 100;
    [SerializeField] Slider _sliderGUI;

    void TakeDamage(short damage)
    {
        _healthPoints -= damage;
        if (_healthPoints <= 0)
        {
            _healthPoints = 0;
            // TODO: game over
        }

        UpdateGUI();
    }

    void UpdateGUI()
    {
        _sliderGUI.value = _healthPoints;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Barrel>() != null)
        {
            TakeDamage(25);
            Destroy(other.gameObject);
        }
    }
}
