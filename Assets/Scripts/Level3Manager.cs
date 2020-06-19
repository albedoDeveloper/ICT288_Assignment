using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level3Manager : MonoBehaviour
{
    [SerializeField] GameObject _cashBar;

    int _cash = 0;

    public void AddCash(int amount)
    {
        _cash += amount;
        UpdateCashGUI();
    }

    void UpdateCashGUI()
    {
        _cashBar.GetComponent<Slider>().value = _cash;
        _cashBar.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "$" + _cash;
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
}
