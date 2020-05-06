using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdFlocker : MonoBehaviour {

    public GameObject train;
    public List<GameObject> birds;
    public float speed;

    [SerializeField]
    private horn horn = null;

    private bool hasFlown = false;

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Train" && !hasFlown)
        {
            train.GetComponent<PathCreation.Examples.PathFollower>().speed = 0;

            if (horn.hornPosition == 1)
            {
                foreach (GameObject bird in birds)
                {
                    if (bird != null)
                    {
                        bird.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5f, 5.0f), Random.Range(1f, 5f), Random.Range(-5f, 5f)) * speed;
                        hasFlown = true;
                    }

                }

            }

        }
    }

}