using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBarrel : Barrel
{
    Rigidbody _rb2 = null;
    int _health2 = 1;

    public float force = 200;
    private Vector3 fpsCharacter;
    private Vector3 defaultRotation = Vector3.zero;
    private TrainHealth lowerTrainHealth = null;
    
    // Start is called before the first frame update
    void Start()
    {
        fpsCharacter = GameObject.FindGameObjectWithTag("FPSCharacter").transform.position;
        lowerTrainHealth = GameObject.Find("Train").GetComponent<TrainHealth>();
        defaultRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, fpsCharacter, force * Time.deltaTime);
        defaultRotation.z -= 100f * Time.deltaTime;
        transform.eulerAngles = defaultRotation;

        if (Vector3.Distance(transform.position, fpsCharacter) < 10f)
        {
            Destroy(gameObject);
            lowerTrainHealth.TakeDamage(25);
        }

    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "barrel")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }


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
