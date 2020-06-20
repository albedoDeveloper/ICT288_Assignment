using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private GameObject _instructionsCanvas = null;

    // Start is called before the first frame update
    public EndPlatform endPlatform;

    public void NewGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        endPlatform.ShowLoadGame();
    }

    public void Instructions()
    {
        _instructionsCanvas.SetActive(true);
    }
}
