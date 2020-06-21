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

    public GameObject FPSController;
    public GameObject VRController;

    public OVRInputModule ovrInputModule;

    public GameObject leftHandAnchor;
    public GameObject rightHandAnchor;

    public GameObject leftOVRController;
    public GameObject rightOVRController;

    public GameObject leftPointerBeam;
    public GameObject rightPointerBeam;



    // Start is called before the first frame update
    void Start()
    {
        if(platformText!=null)
            platformText.text = ("Current Platform:" + Application.platform.ToString());

        if (Application.platform == RuntimePlatform.Android)
        {
            
            if(FPSController != null && VRController != null)
            {
                EnableVRMode();
                if (platformText != null)
                    platformText.text = ("Current Platform:" + Application.platform.ToString());
            }
            //CheckHands();

        }
        else
        {
            if (platformText != null)
                platformText.text = ("Current Platform:" + Application.platform.ToString());
            if (FPSController != null && VRController != null)
            {
                //CheckHands();
                EnableFPSMode();
                
            }
                
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

    private void CheckHands()
    {
        if (leftHandAnchor != null && leftOVRController != null && leftPointerBeam != null && rightHandAnchor != null && rightOVRController != null && rightPointerBeam != null)
        {
            if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            {

                leftOVRController.SetActive(true);
                leftPointerBeam.SetActive(true);
                leftHandAnchor.GetComponent<CharacterInteraction>().enabled = true;

                rightOVRController.SetActive(false);
                rightPointerBeam.SetActive(false);
                rightHandAnchor.GetComponent<CharacterInteraction>().enabled = false;

                if (ovrInputModule != null)
                    ovrInputModule.rayTransform = leftHandAnchor.transform;
                platformText.text = ("Current Platform:" + " LEFT" + ovrInputModule.rayTransform);

            }
            else if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            {
                leftOVRController.SetActive(false);
                leftPointerBeam.SetActive(false);
                leftHandAnchor.GetComponent<CharacterInteraction>().enabled = false;

                rightOVRController.SetActive(true);
                rightPointerBeam.SetActive(true);
                rightHandAnchor.GetComponent<CharacterInteraction>().enabled = true;

                if (ovrInputModule != null)
                    ovrInputModule.rayTransform = rightHandAnchor.transform;
                platformText.text = ("Current Platform:" + " RIGHT " + ovrInputModule.rayTransform);
            }
        }

           


    }
}
