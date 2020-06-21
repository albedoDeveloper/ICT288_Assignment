using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Author: Kye Horbury
/// 
/// </summary>

public class BossBarrel : Barrel
{
    Rigidbody _rb2 = null;
    int _health2 = 30;

    private Vector3 fpsCharacter;

    private Vector3 defaultRotation = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
    {
        _rb2 = GetComponent<Rigidbody>();
        fpsCharacter = GameObject.FindGameObjectWithTag("FPSCharacter").transform.position;
        fpsCharacter = new Vector3(fpsCharacter.x, transform.position.y, fpsCharacter.z);

        defaultRotation = transform.eulerAngles;
    }

    public void InitialPush(int force)
    {
     
    }

    void PushForward(float force)
    {
       
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, fpsCharacter, 10 * Time.deltaTime);

        defaultRotation.x -= 100f * Time.deltaTime;

        transform.eulerAngles = defaultRotation;
    }

    public override void TakeDamage(int amount)
    {
        _health2 -= amount;
        if (_health2 <= 0)
        {
            GameObject manager = GameObject.Find("Level3Manager");
            if (manager != null)
            {
                manager.GetComponent<Level3Manager>().AddCash(50);
            }
            Destroy(gameObject);
        }
    }
}
