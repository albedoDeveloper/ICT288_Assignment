using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdFlocker : MonoBehaviour {

    public GameObject train;
    public List<GameObject> birds; 
    public float speed;
    
    private bool hasFlown = false;
    public AudioSource audio;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    	
	}

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Train")
        {
            //train.GetComponent<PathCreation.Examples.PathFollower>().speed = gameObject.GetComponent<PathCreation.Examples.PathFollower>().speed - 0.02f;

            if (!hasFlown)
            {

                train.GetComponent<PathCreation.Examples.PathFollower>().speed = 0;

                if (Input.GetKey(KeyCode.Y))
                {
                    audio.Play();

                        foreach (GameObject bird in birds)
                        {
                            if (bird != null)
                            {
                                //bird.transform.rotation = Quaternion.Euler(Random.Range(-40.0f, 40.0f), Random.Range(-180f, 180f), Random.Range(-40.0f, 40.0f)).normalized;
                                bird.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5f, 5.0f), Random.Range(1f, 5f), Random.Range(-5f, 5f)) * speed;
                                hasFlown = true;
                            }

                        }
                    }

                }


        }


    }
}
