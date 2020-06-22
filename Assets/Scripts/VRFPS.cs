using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VRFPS : MonoBehaviour
{

    private float deltaTime = 0;
    private float fps = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

            fps = 1.0f / deltaTime;
            GetComponent<TextMeshProUGUI>().text = fps.ToString("F0") + "fps";
        }
    }

}
