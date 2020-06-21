using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{

    private bool _menuActive;

    public PauseMenu _PC_Pause;
    public PauseMenu _VR_Pause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }

    public void MenuSelect()
    {
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_menuActive)
            {
                PauseGame();
                if (Application.platform == RuntimePlatform.Android)
                {
                    _VR_Pause.gameObject.SetActive(true);
                }
                else
                {
                    _PC_Pause.gameObject.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
                _menuActive = true;
            }
            else
            {
                UnPauseGame();
                if (Application.platform == RuntimePlatform.Android)
                {
                    _VR_Pause.gameObject.SetActive(false);
                }
                else
                {
                    _PC_Pause.gameObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                }
                _menuActive = false;
            }
        }
    }

}
