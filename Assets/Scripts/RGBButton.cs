/*
 * Author: Robert Valentic
 */

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RGBButton : MonoBehaviour
{
    private Renderer _renderer = null;
    public TextMeshProUGUI text;
    public bool activate = false;
    public Button myButton;

    private void Start()
    {
        _renderer = transform.Find("Mesh").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activate == true)
        {
            Color col = Color.Lerp(Color.cyan, Color.magenta, Mathf.Cos(Time.time * 10));
            _renderer.material.SetColor("_EmissionColor", col);
        }
        else
        {
            Color col = Color.clear;
            _renderer.material.SetColor("_EmissionColor", col);
        }
    }

    public void ActivateColour()
    {
        activate = true;
    }

    public void DeActivateColour()
    {
        activate = false;
    }

    public void ButtonClick()
    {
        myButton.onClick.Invoke();
    }

}