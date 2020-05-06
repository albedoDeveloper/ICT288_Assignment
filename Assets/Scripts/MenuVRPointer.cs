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
                SceneManager.LoadScene("Kye_Scene 1");
                _rgb = transform.GetComponent<RGBButton>();
                _rgb.enabled = true;
            }
            else if (_rgb != null)
            {
                //_rgb.enabled = false;
                //_rgb = null;
            }
        }
        else
        {
            //_rgb.enabled = false;
            //_rgb = null;
        }
    }
}
