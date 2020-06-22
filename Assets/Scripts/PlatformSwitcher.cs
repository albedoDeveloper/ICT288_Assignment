using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlatformSwitcher : MonoBehaviour
{
    public TextMeshProUGUI platformText;

    public GameObject VREventSystem;
    public GameObject FPSEventSystem;

    public GameObject menuCanvas;

    public OVRInputModule ovrInputModule;

    public GameObject FPSController;
    public GameObject VRController;

    public GameObject leftHandAnchor;
    public GameObject leftOVRController;
    public GameObject leftPointerBeam;

    public GameObject rightHandAnchor;
    public GameObject rightOVRController;
    public GameObject rightPointerBeam;

    // Start is called before the first frame update
    void Start()
    {
        if (platformText != null)
        {
            platformText.text = ("Current Platform:" + Application.platform.ToString());
        }

        if (Application.platform == RuntimePlatform.Android)
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

    // Update is called once per frame
    void Update()
    {
        CheckHands();
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
        if(leftHandAnchor != null && rightHandAnchor != null)
        {
            if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            {
                leftOVRController.SetActive(true);
                leftPointerBeam.SetActive(true);

                rightOVRController.SetActive(false);
                rightPointerBeam.SetActive(false);

                if (VREventSystem != null)
                    ovrInputModule.rayTransform = leftHandAnchor.transform;

                
            }
            else if((OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote)))
            {
                rightOVRController.SetActive(true);
                rightPointerBeam.SetActive(true);

                leftOVRController.SetActive(false);
                leftPointerBeam.SetActive(false);

                if (VREventSystem != null)
                    ovrInputModule.rayTransform = rightHandAnchor.transform;

                
            }
        }
        
    }
}
