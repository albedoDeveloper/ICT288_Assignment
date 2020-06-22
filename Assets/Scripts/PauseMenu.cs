using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    PauseManager pauseManager;

    private bool _menuActive;

    public Button _resumeBtn;
    public Button _mainMenuBtn;

    // Start is called before the first frame update
    void Start()
    {
        pauseManager = FindObjectOfType<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseUnpause()
    {
        if (pauseManager != null)
        {
            pauseManager.UnPauseGame();
        }
    }

    public void ResetLevel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
