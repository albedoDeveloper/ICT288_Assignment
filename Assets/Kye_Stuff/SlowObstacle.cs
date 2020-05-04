using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowObstacle : MonoBehaviour
{
	//GameObject train;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "SlowObstacle")
		{
			if(gameObject.GetComponent<PathCreation.Examples.PathFollower>().speed > 0.5f)
				gameObject.GetComponent<PathCreation.Examples.PathFollower>().speed = gameObject.GetComponent<PathCreation.Examples.PathFollower>().speed - 0.1f;
				//train.GetComponentInChildren<SpeedModifier>().accel = 0.001f;
		}
	}
}