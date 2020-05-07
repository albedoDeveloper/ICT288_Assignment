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
        Debug.Log("TEST ETS TEST");
        SceneManager.LoadScene("MasterScene");
    }

    public void LoadGame()
    {
        Debug.Log("BOLOLOLOLO");
        endPlatform.ShowLoadGame();
    }

    public void Instructions()
    {
        _instructionsCanvas.SetActive(true);
    }
}
