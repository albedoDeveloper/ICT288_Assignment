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
    [SerializeField] GameObject _gameOverPanelVR;
    [SerializeField] GameObject _crossbow;
    [SerializeField] GameObject _vrController;
    [SerializeField] LineRenderer _lineRender;
    [SerializeField] GameObject _gameOverButtonVR;

    public void TakeDamage(short damage)
    {
        _healthPoints -= damage;
        if (_healthPoints <= 0)
        {
            _healthPoints = 0;
        }

        UpdateGUI();

        if (_healthPoints <= 0)
        {
            ShowGameOverPanel();
        }
    }

    void ShowGameOverPanel()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            //Vector3[] p = new Vector3[3];
            //_lineRender.GetPositions(p);
            //p[1].z *= 10;
            //_lineRender.SetPositions(p);
            //_gameOverPanelVR.SetActive(true);
            _gameOverButtonVR.SetActive(true);
            GameObject left = GameObject.Find("VR_Character").transform.Find("TrackingSpace").Find("LeftHandAnchor").Find("PointerBeam").Find("FPSCrossbow").gameObject;
            GameObject right = GameObject.Find("VR_Character").transform.Find("TrackingSpace").Find("RightHandAnchor").Find("PointerBeam").Find("FPSCrossbow").gameObject;
            left.SetActive(false);
            right.SetActive(false);
            GameObject leftOVR = GameObject.Find("VR_Character").transform.Find("TrackingSpace").Find("LeftHandAnchor").Find("OVRControllerPrefab").gameObject;
            GameObject rightOVR = GameObject.Find("VR_Character").transform.Find("TrackingSpace").Find("RightHandAnchor").Find("OVRControllerPrefab").gameObject;
            leftOVR.SetActive(true);
            rightOVR.SetActive(true);
        }
        else
        {
            _gameOverPanel.SetActive(true);
        }
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
            TakeDamage(5);
            Destroy(other.gameObject);
        }
    }
}
