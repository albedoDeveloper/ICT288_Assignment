using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Author: Kye Horbury
/// </summary>
public class CutSceneOneStart : MonoBehaviour
{
    [SerializeField]
    private int riseSpeed = 1;

    [SerializeField]
    private int towardSpeed = 1;

    [SerializeField]
    private GameObject dolphin;

    [SerializeField]
    private GameObject staticDolphin;

    [SerializeField]
    private GameObject tear;

    [SerializeField]
    private TextMeshProUGUI talkingText = null;

    [SerializeField]
    private AudioSource dolphinNoise = null;

    [SerializeField]
    private GameObject canvas = null;


    [SerializeField]
    private GameObject canvasAndroid = null;

    private uint displayText = 0;

    private bool re = true;
    private bool movedOnce = true;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveUp());
        talkingText.transform.position = new Vector3(gameObject.GetComponentInChildren<Camera>().transform.position.x + 20, gameObject.GetComponentInChildren<Camera>().transform.position.y - 5, gameObject.GetComponentInChildren<Camera>().transform.position.z - 2);
            //new Vector3(Screen.width / 2, Screen.height / 6, talkingText.transform.position.z);

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
                talkingText.text = "Fairuz the Dolphin: Finally you have arrived!\nMr.Jetty Manager I desperately need your help!\n (Press E or the Trigger button to continue)";
                break;

            case 2:
                dolphinNoise.Play();
                talkingText.text = "You: Sure th... \nWait you are dolphin, how can I understand you??";
                break;

            case 3:
                talkingText.text = "Fairuz the Dolphin: Don't worry about that now, \n our livelyhood is in danger!";
                break;

            case 4:
                dolphinNoise.Play();
                talkingText.text = "You: Uh... I see. What has happened?";
                break;

            case 5:
                talkingText.text = "Fairuz the Dolphin: The Princess has beeen captured at the\n end of the jetty by the giant seagull, Robert the Terrible,\n and they need someone to rescue her!\n Will you be the hero we need?";
                break;

            case 6:
                dolphinNoise.Play();
                talkingText.text = "You: Sure thing! It something too serious for me to just ignore.\n But what can I do to help?";
                break;

            case 7:
                talkingText.text = "Fairuz the Dolphin: Hmm you need to get there are fast as possible...\n I know! How about you take the jetty train, \nit will get you to the end way faster then walking!\n (Plus its cheap to ride too!)";
                break;

            case 8:
                dolphinNoise.Play();
                talkingText.text = "You: Okay, the train it is! Don't worry, I will save the princess!";
                break;

            case 9:
                StartCoroutine(WaitForTear());
                break;

            case 11:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;

        }

        if ((Input.GetKeyDown(KeyCode.E) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) && displayText != 9 && displayText != 0)
        {
            displayText++;
        }
    }



    IEnumerator MoveUp()
    {
        yield return new WaitForSeconds(0.5f);

        while (transform.position.y < 58f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (riseSpeed * Time.deltaTime), transform.position.z);
            yield return null;
        }

        yield return StartCoroutine(MoveTowards());

    }


    IEnumerator MoveTowards()
    {

        while (Vector3.Distance(transform.position, dolphin.transform.position) > 12f)
        {
            Vector3 lTargetDir = dolphin.transform.position - transform.position;

            lTargetDir.y = 0.0f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), towardSpeed * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, dolphin.transform.position, towardSpeed * Time.deltaTime);
            yield return null;

        }

        displayText++;
        dolphinNoise.Play();
        if (Application.platform == RuntimePlatform.Android)
        {
            canvasAndroid.transform.position = canvas.transform.position;
            canvasAndroid.transform.rotation = canvas.transform.rotation;

            canvasAndroid.transform.GetChild(0).position = canvas.transform.transform.GetChild(0).position;

            talkingText = canvasAndroid.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }
    }

    IEnumerator WaitForTear()
    {
        displayText++;
        if (re)
        {
            talkingText.transform.position = new Vector3(gameObject.GetComponentInChildren<Camera>().transform.position.x + 22, gameObject.GetComponentInChildren<Camera>().transform.position.y - 2, gameObject.GetComponentInChildren<Camera>().transform.position.z - 15);
            re = false;

        }
        talkingText.text = "Please hurry,\n I miss her so much...";
        if (Application.platform == RuntimePlatform.Android && movedOnce)
        {
            canvasAndroid.transform.position = canvas.transform.position;
            canvasAndroid.transform.rotation = canvas.transform.rotation;

            canvasAndroid.transform.GetChild(0).position = new Vector3( canvas.transform.transform.GetChild(0).position.x - 4, canvas.transform.transform.GetChild(0).position.y, canvas.transform.transform.GetChild(0).position.z - 15);

            talkingText = canvasAndroid.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        //dolphinNoise.Play();

        transform.position = new Vector3(dolphin.transform.position.x + 2.5f, dolphin.transform.position.y + 4.2f, dolphin.transform.position.z + 3.4f);
        Destroy(dolphin);
        dolphin = Instantiate(staticDolphin);
        transform.LookAt(new Vector3(dolphin.transform.position.x, dolphin.transform.position.y + 2f, dolphin.transform.position.z));
        yield return new WaitForSeconds(1f);
        Instantiate(tear);
        yield return new WaitForSeconds(1.5f);

    }
}