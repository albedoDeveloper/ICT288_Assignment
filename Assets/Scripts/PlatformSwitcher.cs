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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.platform + "ASKGHDLAGH:RFJLASHFSKAFJHASHL:LSAJF<>BHSLADFJSAK");
        platformText.text = ("Current Platform:" + Application.platform.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            platformText.text = (Application.platform.ToString() + "WOOO HOOOOOOOOO");
            EnableVRMode();
        }
        else
        {
            platformText.text = (Application.platform.ToString() + ": I mean not the result we looking for but still works");
            EnableFPSMode();
        }
    }

    public void EnableVRMode()
    {
        if (menuCanvas.GetComponent<GraphicRaycaster>())
        {
            menuCanvas.GetComponent<GraphicRaycaster>().enabled = false;
        }
        if (menuCanvas.GetComponent<OVRRaycaster>())
        {
            menuCanvas.GetComponent<OVRRaycaster>().enabled = true;
        }

        VREventSystem.SetActive(true);
        FPSEventSystem.SetActive(false);
    }

    public void EnableFPSMode()
    {
        if (menuCanvas.GetComponent<GraphicRaycaster>())
        {
            menuCanvas.GetComponent<GraphicRaycaster>().enabled = true;
        }
        if (menuCanvas.GetComponent<OVRRaycaster>())
        {
            menuCanvas.GetComponent<OVRRaycaster>().enabled = false;
        }
        VREventSystem.SetActive(false);
        FPSEventSystem.SetActive(true);
    }
}
