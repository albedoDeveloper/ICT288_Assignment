using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Author: Kye Horbury
/// </summary>
public class FinalCutScene : MonoBehaviour
{


    [SerializeField]
    private GameObject dolphin;



    [SerializeField]
    private GameObject youdolphin;


    [SerializeField]
    private GameObject end;

    [SerializeField]
    private TextMeshProUGUI talkingText = null;


    [SerializeField]
    private AudioSource dolphinNoise = null;

    [SerializeField]
    private GameObject canvas = null;

    private uint displayText = 1;

    private bool re = true;

    private bool changePos = true;


    // Start is called before the first frame update
    void Start()
    {
       if (Application.platform == RuntimePlatform.Android)
       {
            canvas = GameObject.Find("CanvasAnd");
            talkingText = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
       }



    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }

    // Update is called once per frame
    void Update()
    {


        switch (displayText)
        {
            case 1:
                talkingText.text = "Dolphin Princess: Thank you brave Jetty Manager...\n You have saved me from Robert the Terrible and saved the Jetty!";
                talkingText.color =  new Color32(255, 182, 193, 255);
                break;

            case 2:
                dolphinNoise.Play();
                talkingText.text = "Fairuz the Dolphin: How can we ever repay you?";
                talkingText.color = new Color32(0, 0, 225, 255);
                break;
 
            case 3:
                talkingText.text = "You: There is no need! I am just doing my job!";
                talkingText.color = new Color32(225, 225, 225, 225);
                break;

            case 4:
                dolphinNoise.Play();
                talkingText.color = new Color32(255, 182, 193, 255);
                talkingText.text = "Dolphin Princess: You should come to our\n underwater castle to celebrate!";
                break;

            case 5:
                talkingText.text = "Fairuz the Dolphin: Yeah, what a great idea!" ;
                talkingText.color = new Color32(0, 0, 225, 255);
                break;

            case 6:
                dolphinNoise.Play();
                talkingText.text = "You: As much as I would love to, I am not a dolphin\n so I can't swim that far";
                talkingText.color = new Color32(225, 225, 225, 225);
                break;

            case 7:
                dolphinNoise.Play();
                talkingText.text = "Fairuz the Dolphin: Uhh...";
                talkingText.color = new Color32(0, 0, 225, 255);
                break;

            case 8:
                talkingText.text = "Dolphin Pricess: ... Are you okay, Jetty Manager?";
                talkingText.color = new Color32(255, 182, 193, 255);
                break;

            case 9:
                dolphinNoise.Play();
                talkingText.text = "You: What do you mean?";
                talkingText.color = new Color32(225, 225, 225, 225);
                break;


            case 10:
                talkingText.text = "Fairuz the Dolphin: Manager, you ARE a Dolphin!";
                talkingText.color = new Color32(0, 0, 225, 255);
                break;

            case 11:
                talkingText.text = "";
                if (re)
                {
                    StartCoroutine(ShowSelf());
                    re = false;
                }
                break;

            case 12:
                talkingText.color = new Color32(225, 225, 225, 225);
                talkingText.text = "You: I have no idea what you are talking about!";

               if (Application.platform == RuntimePlatform.Android && changePos)
               {
                    canvas.transform.GetChild(0).transform.localPosition = new Vector3(canvas.transform.GetChild(0).transform.localPosition.x, canvas.transform.GetChild(0).transform.localPosition.y, canvas.transform.GetChild(0).transform.localPosition.z - 20);
                    canvas.transform.localScale = new Vector3(canvas.transform.localScale.x * -1, canvas.transform.localScale.y, canvas.transform.localScale.z);
                    changePos = false;
               }

                break;


            case 13:
                dolphinNoise.Play();
                end.SetActive(true);
                talkingText.text = "";
                break;

            case 14:
                SceneManager.LoadScene(0);
                break;

            default:
                break;

        }

        if ((Input.GetKeyDown(KeyCode.E) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) && displayText != 0 /*&& displayText != 11*/)
        {
            displayText++;
        }

        Debug.Log(displayText);
    }



    IEnumerator ShowSelf()
    {
        dolphin.SetActive(true);

        while  (Vector3.Dot(transform.forward, (dolphin.transform.position - transform.position).normalized) != 1)
        {
 
            Vector3 lTargetDir = dolphin.transform.position - transform.position;

            lTargetDir.y = 0.0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), 30 * Time.deltaTime);

            yield return null;
        }



    }
    
}