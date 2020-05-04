using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotation : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(90.175f, -235.056f, 386.965f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(90.175f,-235.056f,386.965f);
    }
}
