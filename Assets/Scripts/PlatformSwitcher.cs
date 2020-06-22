using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlatformSwitcher : MonoBehaviour
{
    public TextMeshProUGUI platformText;

    public GameObject VREventSystem;
    public GameObject FPSEventSystem;

    public GameObject menuCanvas;

    public GameObject FPSController;
    public GameObject VRController;

    // Start is called before the first frame update
    void Start()
    {
        if (platformText != null)
        {
            platformText.text = ("Current Platform:" + Application.platform.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (platformText != null)
            {
                platformText.text = ("Current Platform:" + Application.platform.ToString());
            }

            EnableVRMode();
        }
        else
        {
            if (platformText != null)
            {
                platformText.text = ("Current Platform:" + Application.platform.ToString());
            }

            EnableFPSMode();
        }
    }

    public void EnableVRMode()
    {
        if (FPSController != null)
        {
            FPSController.SetActive(false);
        }

        if (VRController != null)
        {
            VRController.SetActive(true);
        }

        if (menuCanvas != null)
        {
            if (menuCanvas.GetComponent<GraphicRaycaster>())
            {
                menuCanvas.GetComponent<GraphicRaycaster>().enabled = false;
            }
            if (menuCanvas.GetComponent<OVRRaycaster>())
            {
                menuCanvas.GetComponent<OVRRaycaster>().enabled = true;
            }
        }
        

        VREventSystem.SetActive(true);
        FPSEventSystem.SetActive(false);
    }

    public void EnableFPSMode()
    {
        if (FPSController != null)
        {
            FPSController.SetActive(true);
        }

        if (VRController != null)
        {
            VRController.SetActive(false);
        }

        if (menuCanvas != null)
        {
            if (menuCanvas.GetComponent<GraphicRaycaster>())
            {
                menuCanvas.GetComponent<GraphicRaycaster>().enabled = true;
            }
            if (menuCanvas.GetComponent<OVRRaycaster>())
            {
                menuCanvas.GetComponent<OVRRaycaster>().enabled = false;
            }
        }
         
        VREventSystem.SetActive(false);
        FPSEventSystem.SetActive(true);
    }
}
