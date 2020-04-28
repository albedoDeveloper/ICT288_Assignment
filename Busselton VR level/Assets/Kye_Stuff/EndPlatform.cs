using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class EndPlatform : MonoBehaviour {

    public Gui scoreInfo;
    public GameObject showHighscore;
    public TextMeshProUGUI displayScore;
    public GameObject train;

    private bool stopClear = true;
    private bool stopAdd = false;
    // Use this for initialization

    void Start ()
    {
        //PlayerPrefs.DeleteAll();

    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(PlayerPrefs.GetInt("TotalSize"));

    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Train")
        {
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
                            for (int j = PlayerPrefs.GetInt("TotalSize"); j < i ; j--)
                            {
                                if (!PlayerPrefs.HasKey((j + 1).ToString()) && j != 4)
                                {
                                    PlayerPrefs.SetString((j + 1).ToString(), (j).ToString());
                                    PlayerPrefs.SetInt("TotalSize", PlayerPrefs.GetInt("TotalSize") + 1);
                                }
                                    

                                else
                                    PlayerPrefs.SetString((j).ToString(), (j - 1).ToString());
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
        SceneManager.LoadScene(0);
        showHighscore.SetActive(false);
    }

    

}
