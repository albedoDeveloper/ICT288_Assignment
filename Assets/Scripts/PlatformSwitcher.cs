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

    public GameObject OVRControllerLeft;
    public GameObject OVRControllerRight;

    public GameObject pointerBeamLeft;
    public GameObject pointerBeamRight;

    // Start is called before the first frame update
    void Start()
    {
        platformText.text = ("Current Platform:" + Application.platform.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            platformText.text = ("Current Platform:" + Application.platform.ToString());
            EnableVRMode();
            CheckHands();
        }
        else
        {
            platformText.text = ("Current Platform:" + Application.platform.ToString());
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

    private void CheckHands()
    {
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
        {
            if(OVRControllerLeft != null && pointerBeamLeft != null)
            {
                OVRControllerLeft.SetActive(true);
                pointerBeamLeft.SetActive(true);
            }

        }
        else
        {
            if (OVRControllerLeft != null && pointerBeamLeft != null)
            {
                OVRControllerLeft.SetActive(false);
                pointerBeamLeft.SetActive(false);
            }
        }

        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
        {
            if (OVRControllerRight != null && pointerBeamRight != null)
            {
                OVRControllerRight.SetActive(true);
                pointerBeamRight.SetActive(true);
            }
        }
        else
        {
            if (OVRControllerRight != null && pointerBeamRight != null)
            {
                OVRControllerRight.SetActive(false);
                pointerBeamRight.SetActive(false);
            }
        }
    }

}
