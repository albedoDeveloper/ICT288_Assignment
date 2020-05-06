using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horn : MonoBehaviour
{
    private Vector3 startPos;
    [HideInInspector]
    public int hornPosition = 0;

    void Start()
    {
        startPos = transform.localPosition;   
    }

    private void Update()
    {
        if (hornPosition == 1)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 0.01f, transform.localPosition.y, transform.localPosition.z);
            if (transform.localPosition.x >= -17.53f)
                hornPosition = 2;
        }  

        else if (hornPosition == 2)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - 0.01f, transform.localPosition.y, transform.localPosition.z);
            if (transform.localPosition.x <= -17.60f)
                hornPosition = 0;
        }
 
    }

    private void OnMouseDown()
    {
        if (hornPosition == 0)
        {
            GetComponent<AudioSource>().Play();
            hornPosition = 1;
        }
           
    }
}
