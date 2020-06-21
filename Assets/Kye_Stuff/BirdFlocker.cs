using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BirdFlocker : MonoBehaviour {

    public GameObject train;
    public List<GameObject> birds;
    public float speed;

    [SerializeField]
    private horn horn = null;
    private bool hasFlown = false;

    [SerializeField] Level1Tutorial _tutorial;

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Train" && !hasFlown)
        {
            if (_tutorial != null)
            {
                _tutorial.HitBirds();
            }

            train.GetComponent<PathCreation.Examples.PathFollower>().speed = 0;
            train.GetComponent<PathCreation.Examples.PathFollower>().enabled = false;

            if (horn.hornPosition == 1)
            {
                foreach (GameObject bird in birds)
                {
                    if (bird != null)
                    {
                        bird.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5f, 5.0f), Random.Range(1f, 5f), Random.Range(-5f, 5f)) * speed;
                        train.GetComponent<PathCreation.Examples.PathFollower>().enabled = true;
                        hasFlown = true;
                    }
                    Destroy(bird, 10);
                }
            }
        }
    }
}