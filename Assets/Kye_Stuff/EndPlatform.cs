using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class EndPlatform : MonoBehaviour {

    [SerializeField] private FPSMouseLook _mouseLook = null;
    public Gui scoreInfo;
    public GameObject showHighscore;
    public GameObject showSave;
    public GameObject loadGame;
    public TextMeshProUGUI displayScore;
    public GameObject train;

    private bool stopClear = true;
    private bool stopAdd = false;
    // Use this for initialization

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //Cursor.lockState = CursorLockMode.None;
        //ShowLoadGame();
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Train")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            _mouseLook.enabled = false;

            train.GetComponent<PathCreation.Examples.PathFollower>().speed = 0;
            train.GetComponent<PathCreation.Examples.PathFollower>().enabled = false;

            showHighscore.SetActive(true);

            if (stopClear)
            {
                displayScore.text = "Highscores";

                for (int i = 0; i < 5 && !stopAdd; i++)
                {
                    if (PlayerPrefs.HasKey(i.ToString()))
                    {
                        if (scoreInfo.timer < float.Parse(PlayerPrefs.GetString(i.ToString())))
                        {
                            Debug.Log(i);
                            for (int j = PlayerPrefs.GetInt("TotalSize"); j > i; j--)
                            {
                                if (j < 5)
                                {

                                    PlayerPrefs.SetString((j).ToString(), (PlayerPrefs.GetString((j - 1).ToString())));

                                    if (j == PlayerPrefs.GetInt("TotalSize"))
                                        PlayerPrefs.SetInt("TotalSize", PlayerPrefs.GetInt("TotalSize") + 1);
                                }
                            }

                            PlayerPrefs.SetString(i.ToString(), scoreInfo.timer.ToString());
                            stopAdd = true;
                        }
                    }

                    else
                    {
                        PlayerPrefs.SetString(i.ToString(), scoreInfo.timer.ToString());
                        PlayerPrefs.SetInt("TotalSize", i + 1);
                        stopAdd = true;

                    }


                }

                for (int i = 0; i < PlayerPrefs.GetInt("TotalSize"); i++)
                {
                    displayScore.text = displayScore.text + "\n" + (i + 1).ToString() + ": " + Math.Round(Convert.ToDecimal(PlayerPrefs.GetString(i.ToString())), 2);
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

    public void SaveGame()
    { 
        showHighscore.SetActive(false);
        showSave.SetActive(true);
    }

    public void SaveGameOne()
    {
        PlayerPrefs.SetInt("SaveFileOne", SceneManager.GetActiveScene().buildIndex);
        showHighscore.SetActive(true);
        showSave.SetActive(false);
        Debug.Log(PlayerPrefs.HasKey("SaveFileOne"));
    }

    public void SaveGameTwo()
    {
        PlayerPrefs.SetInt("SaveFileTwo", SceneManager.GetActiveScene().buildIndex);
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
