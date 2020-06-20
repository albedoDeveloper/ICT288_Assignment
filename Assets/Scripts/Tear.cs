using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Kye Horbury
/// 
/// </summary>

public class Tear : MonoBehaviour
{
    bool startFall = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TearFall");
    }

    // Update is called once per frame
    void Update()
    {
        if(startFall)
            transform.position = new Vector3(transform.position.x, transform.position.y - (2f * Time.deltaTime), transform.position.z);
    }

    IEnumerator TearFall()
    {
        var tearGrowSpeed = 0.055f * Time.deltaTime;

        while (transform.localScale.z <= 0.1)
        {

            transform.localScale = new Vector3(transform.localScale.x + tearGrowSpeed, transform.localScale.y + tearGrowSpeed, transform.localScale.z + tearGrowSpeed);

            yield return null;

        }

        startFall = true;
    }
}
