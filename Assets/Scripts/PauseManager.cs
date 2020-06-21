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
        if (Application.platform == RuntimePlatform.Android)
        {
            _VR_Pause.gameObject.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            _PC_Pause.gameObject.SetActive(true);
        }
        _menuActive = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        if (Application.platform == RuntimePlatform.Android)
        {
            _VR_Pause.gameObject.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            _PC_Pause.gameObject.SetActive(false);
        }
        _menuActive = false;
    }

    public void MenuSelect()
    {
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_menuActive)
            {
                PauseGame();
                
            }
            else
            {
                UnPauseGame();
            }
        }
    }

}
