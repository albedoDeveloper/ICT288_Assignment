using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowObstacle : MonoBehaviour
{
	public GameObject train;

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
		if (collider.tag == "Train")
		{
			if (train.GetComponent<PathCreation.Examples.PathFollower>().speed > 0.5f)
                train.GetComponent<PathCreation.Examples.PathFollower>().speed = train.GetComponent<PathCreation.Examples.PathFollower>().speed - 0.4f;
				//train.GetComponentInChildren<SpeedModifier>().accel = 0.001f;
		}
	}
}