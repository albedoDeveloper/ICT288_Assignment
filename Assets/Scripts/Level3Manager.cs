using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Level3Manager : MonoBehaviour
{
    [SerializeField] GameObject _cashbarVR;
    [SerializeField] GameObject _cashbarPC;

    int _cash = 0;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void AddCash(int amount)
    {
        _cash += amount;
        UpdateCashGUI();
    }

    void UpdateCashGUI()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _cashbarVR.GetComponent<Slider>().value = _cash;
            _cashbarVR.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "$" + _cash;
        }
        else
        {
            _cashbarPC.GetComponent<Slider>().value = _cash;
            _cashbarPC.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "$" + _cash;        
        }
    }

    public int GetCash()
    {
        return _cash;
    }

    public void SubtractCash(int amount)
    {
        _cash -= amount;
        if (_cash < 0)
        {
            _cash = 0;
        }

        UpdateCashGUI();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level3");
    }
}
