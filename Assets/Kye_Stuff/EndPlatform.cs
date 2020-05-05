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
                            Debug.Log(i);
                            for (int j = PlayerPrefs.GetInt("TotalSize"); j > i ; j--)
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
        SceneManager.LoadScene(0);
        showHighscore.SetActive(false);
    }

    

}
