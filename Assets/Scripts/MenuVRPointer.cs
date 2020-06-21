/*
 * Author: Robert Valentic
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVRPointer : MonoBehaviour
{
    private RaycastHit _hit;
    private RGBButton _rgb = null;

    private void Update()
    {
        PerformRaycast();
    }

    private void PerformRaycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit))
        {
            if (_hit.collider.CompareTag("Button"))
            {
                //SceneManager.LoadScene("Kye_Scene 1");
                _rgb = _hit.collider.transform.GetComponent<RGBButton>();
                if (_rgb != null)
                {
                    
                    _rgb.ActivateColour();
                    //_rgb.enabled = true;
                    if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || Input.GetMouseButton(0))
                    { 
                        _rgb.ButtonClick();
                    }
                }
            }
            else if (_rgb != null)
            {
                _rgb.DeActivateColour();
                //_rgb.enabled = false;
                _rgb = null;
            }
        }
        else if(_rgb != null)
        {
            _rgb.DeActivateColour();
            //_rgb.enabled = false;
            _rgb = null;
        }
    }
}
