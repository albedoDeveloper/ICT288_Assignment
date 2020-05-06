/*
 * Author: Robert Valentic
 */

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class RGBButton : MonoBehaviour
{
    private Renderer _renderer = null;
    public TextMeshProUGUI text;
    public bool activate = false;

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
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Kye_Scene 1");
            }

        }
        else
        {
            Color col = Color.clear;
            _renderer.material.SetColor("_EmissionColor", col);
        }
    }

    public void Activate()
    {
        activate = true;
    }

    public void DeActivate()
    {
        activate = false;
    }

}