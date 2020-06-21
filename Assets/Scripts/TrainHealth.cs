using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrainHealth : MonoBehaviour
{
    short _healthPoints = 100;
    [SerializeField] GameObject _healthPC;
    [SerializeField] GameObject _healthVR;
    [SerializeField] GameObject _gameOverPanel;

    public void TakeDamage(short damage)
    {
        _healthPoints -= damage;
        if (_healthPoints <= 0)
        {
            _healthPoints = 0;
            ShowRestartLevelPanel();
        }

        UpdateGUI();
    }

    void ShowRestartLevelPanel()
    {
        _gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    void UpdateGUI()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _healthVR.GetComponent<Slider>().value = _healthPoints;
            _healthVR.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "" + _healthPoints;
        }
        else
        {
            _healthPC.GetComponent<Slider>().value = _healthPoints;
            _healthPC.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "" + _healthPoints;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Barrel>() != null)
        {
            TakeDamage(100);
            Destroy(other.gameObject);
        }
    }
}
