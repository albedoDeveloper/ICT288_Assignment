using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Kye Horbury
/// 
/// </summary>
public class BossBarrelParent : MonoBehaviour
{


    private Vector3 fpsCharacter;
    // Start is called before the first frame update
    void Start()
    {
        fpsCharacter = GameObject.FindGameObjectWithTag("FPSCharacter").transform.position;
        fpsCharacter = new Vector3(fpsCharacter.x - 40, transform.position.y, fpsCharacter.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, fpsCharacter) > 100f)
            transform.position = Vector3.MoveTowards(transform.position, fpsCharacter, 5 * Time.deltaTime);

    }

}
