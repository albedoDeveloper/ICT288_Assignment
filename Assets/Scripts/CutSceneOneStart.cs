using System.Collections;
using UnityEngine;
using TMPro;

public class CutSceneOneStart : MonoBehaviour
{
    [SerializeField]
    private int speed = 1;

    [SerializeField]
    private GameObject dolphin;

    [SerializeField]
    private GameObject tear;

    [SerializeField]
    private TextMeshProUGUI talkingText = null;

    private int displayText = 0;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MoveUp");
        Debug.Log(Vector3.Distance(transform.position, dolphin.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        if (displayText == 1)
        {
            talkingText.text = "Robert, my love, hold me tight. Kiss me like you used to...";
        }

        if (displayText == 2)
        {
            Instantiate(tear);
            talkingText.text = "Pls Robert bby...";
            transform.position = new Vector3(dolphin.transform.position.x + 2.5f, dolphin.transform.position.y + 4.2f, dolphin.transform.position.z + 3.4f);

            transform.LookAt(new Vector3(dolphin.transform.position.x, dolphin.transform.position.y + 2f, dolphin.transform.position.z));
            dolphin.GetComponent<Animator>().enabled = false;
            displayText++;

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            displayText++;
        }
    }

    IEnumerator MoveUp()
    {

        while (transform.position.y < 58f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), speed - 0.5f);

            transform.position = Vector3.MoveTowards(transform.position, dolphin.transform.position, speed);
            yield return null;

        }

        displayText++;

    }



}