using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSwerve : MonoBehaviour
{
    Rigidbody _rb = null;
    int _health = 1;

    private GameObject jetty = null;

    private Vector3 newPosition;
    private Vector3 defaultRotation = Vector3.zero;

    [SerializeField]
    private int force = 1000;

    private bool shouldRealign = true;

    private float randomRange = 0;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
         transform.eulerAngles = defaultRotation;
          jetty = GameObject.Find("BusseltonJetty");
    }

    public void InitialPush(int force)
    {
        this.force = force;
    }


    private void Update()
    {

        //Set an intial movement
        if (shouldRealign)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
           
            transform.eulerAngles = defaultRotation;

            if (randomRange == 0)
            {
                randomRange = Random.Range(1f, 2f);
            }

            else if (randomRange <= 1.5)
                randomRange = 1.6f;

            else
                randomRange = 1.4f;

            if (randomRange <= 1.5)
            {
                newPosition = new Vector3(938, transform.position.y, transform.position.z - 30);
            }

            else
            {
                newPosition = new Vector3(969.17f, transform.position.y, transform.position.z - 30);
            }

            transform.LookAt(newPosition);
            defaultRotation = transform.eulerAngles;


            shouldRealign = false;
            
        }


        //Vector3 lTargetDir = newPosition - transform.position;

        //lTargetDir.y = 0.0f;
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), force * Time.deltaTime);

        // transform.LookAt(newPosition);
        //_rb.AddForce(transform.forward * Time.deltaTime * force);

        transform.position = Vector3.MoveTowards(transform.position, newPosition, 15 * Time.deltaTime);

        defaultRotation.x += 150f * Time.deltaTime;

        transform.eulerAngles = defaultRotation;

        if(Vector3.Distance(newPosition, transform.position) < 2)
            shouldRealign = true;

    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
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