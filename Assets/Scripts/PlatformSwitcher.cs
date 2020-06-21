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

    //public GameObject leftHandAnchor;
    //public GameObject rightHandAnchor;


    // Start is called before the first frame update
    void Start()
    {
        if(platformText!=null)
            platformText.text = ("Current Platform:" + Application.platform.ToString());

        if (platformText != null)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                platformText.text = ("Current Platform:" + Application.platform.ToString());
                EnableVRMode();
                //CheckHands();
            }
            else
            {
                platformText.text = ("Current Platform:" + Application.platform.ToString());
                EnableFPSMode();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
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
        Cursor.lockState = CursorLockMode.Locked;
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

    //private void CheckHands()
    //{
    //    if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
    //    {
    //        if(leftHandAnchor != null)
    //        {
    //            leftHandAnchor.SetActive(true);
    //            if(VREventSystem != null)
    //                VREventSystem.GetComponent<HandedInputSelector>().ovrInputModule.rayTransform = leftHandAnchor.transform;
    //        }

    //    }
    //    else
    //    {
    //        if (leftHandAnchor != null)
    //        {
    //            leftHandAnchor.SetActive(false);
    //        }
    //    }

    //    if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
    //    {
    //        if (rightHandAnchor != null)
    //        {
    //            rightHandAnchor.SetActive(true);
    //            if (VREventSystem != null)
    //                VREventSystem.GetComponent<HandedInputSelector>().ovrInputModule.rayTransform = rightHandAnchor.transform;
    //        }
    //    }
    //    else
    //    {
    //        if (rightHandAnchor != null)
    //        {
    //            rightHandAnchor.SetActive(false);
    //        }
    //    }
    //}

}
