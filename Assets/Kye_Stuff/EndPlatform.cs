using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


/// <summary>
///  Author: Kye Horbury
/// 
/// </summary>
public class EndPlatform : MonoBehaviour {

    public Gui scoreInfo;
    public GameObject showHighscore;
    public GameObject showSave;
    public GameObject loadGame;
    public TextMeshProUGUI displayScore;
    public GameObject train;

    public GameObject VRCanvas;
    public GameObject VRSave;
    public GameObject VRLoad;
    public TextMeshProUGUI VRDisplayScore;

    private bool stopClear = true;
    private bool stopAdd = false;

    [HideInInspector]
    public bool finishedGame = false;
    // Use this for initialization

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //Cursor.lockState = CursorLockMode.None;
        //ShowLoadGame();

        if(Application.platform == RuntimePlatform.Android)
        {
            
            showSave = VRSave;
            loadGame = VRLoad;
            displayScore = VRDisplayScore;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider collider)
    {
        var currentLevel = (SceneManager.GetActiveScene().buildIndex - 1).ToString();
        Cursor.lockState = CursorLockMode.None;

        if (collider.tag == "Train")
        {
            Cursor.visible = true;
            finishedGame = true;

            train.GetComponent<PathCreation.Examples.PathFollower>().speed = 0;
            train.GetComponent<PathCreation.Examples.PathFollower>().enabled = false;

            if (Application.platform == RuntimePlatform.Android)
            {
                VRCanvas.SetActive(true);
            }
                showHighscore.SetActive(true);
            

            if (stopClear)
            {
                displayScore.text = "Highscores for level" + currentLevel;

                for (int i = 0; i < 5 && !stopAdd; i++)
                {
                    if (PlayerPrefs.HasKey(i.ToString() + currentLevel))
                    {
                        if (scoreInfo.timer < float.Parse(PlayerPrefs.GetString(i.ToString() + currentLevel)))
                        {
                            Debug.Log(i);
                            for (int j = PlayerPrefs.GetInt("TotalSize" + currentLevel); j > i; j--)
                            {
                                if (j < 5)
                                {

                                    PlayerPrefs.SetString((j).ToString() + currentLevel, PlayerPrefs.GetString((j - 1).ToString() + currentLevel));

                                    if (j == PlayerPrefs.GetInt("TotalSize" + currentLevel))
                                        PlayerPrefs.SetInt("TotalSize" + currentLevel, PlayerPrefs.GetInt("TotalSize" + currentLevel) + 1);
                                }
                            }

                            PlayerPrefs.SetString(i.ToString() + currentLevel, scoreInfo.timer.ToString());
                            stopAdd = true;
                        }
                    }

                    else
                    {
                        PlayerPrefs.SetString(i.ToString() + currentLevel, scoreInfo.timer.ToString());
                        PlayerPrefs.SetInt("TotalSize" + currentLevel, i + 1);
                        stopAdd = true;

                    }


                }

                for (int i = 0; i < PlayerPrefs.GetInt("TotalSize" + currentLevel); i++)
                {
                    displayScore.text = displayScore.text + "\n" + (i + 1).ToString() + ": " + Math.Round(Convert.ToDecimal(PlayerPrefs.GetString(i.ToString() + currentLevel)), 2);
                }

                stopClear = false;

            }

        }

    }

    public void ResetLevel()
    {
        showHighscore.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        showHighscore.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void SaveGame()
    { 
        showHighscore.SetActive(false);
        showSave.SetActive(true);
    }

    public void SaveGameOne()
    {
        PlayerPrefs.SetInt("SaveFileOne", SceneManager.GetActiveScene().buildIndex + 1);
        showHighscore.SetActive(true);
        showSave.SetActive(false);
        Debug.Log(PlayerPrefs.HasKey("SaveFileOne"));
    }

    public void SaveGameTwo()
    {
        PlayerPrefs.SetInt("SaveFileTwo", SceneManager.GetActiveScene().buildIndex + 1);
        showHighscore.SetActive(true);
        showSave.SetActive(false);
    }


    public void ShowLoadGame()
    {
        loadGame.SetActive(true);

        if (!PlayerPrefs.HasKey("SaveFileOne"))
        {
            loadGame.transform.GetChild(0).gameObject.SetActive(true);
            loadGame.transform.GetChild(3).gameObject.SetActive(false);
        }

        else
            loadGame.transform.GetChild(0).gameObject.SetActive(false);

        if (!PlayerPrefs.HasKey("SaveFileTwo"))
        {
            loadGame.transform.GetChild(1).gameObject.SetActive(true);
            loadGame.transform.GetChild(4).gameObject.SetActive(false);
        }

        else
            loadGame.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void LoadGameOne()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SaveFileOne"));
    }

    public void LoadGameTwo()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SaveFileTwo"));
    }


    public void showHighScore()
    {
        showHighscore.SetActive(true);
        displayScore.text = "Highscores";

        for (int i = 0; i < PlayerPrefs.GetInt("TotalSize"); i++)
        {
            displayScore.text = displayScore.text + "\n" + (i + 1).ToString() + ": " + Math.Round(Convert.ToDecimal(PlayerPrefs.GetString(i.ToString())), 2);
        }
    }

}
