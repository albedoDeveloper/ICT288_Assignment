using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;



public class SwapToNewTrack : MonoBehaviour {

	public SwapDecide decider;
	public PathCreator left, right = null;
	public PathCreation.Examples.PathFollower follower = null;

	[HideInInspector]
	public float distancetravelled;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Train")
		{
			
			if (decider.path == 1) //Left
			{
				if (left != null)
				{
					follower.pathCreator = left;
					transform.position = left.path.GetPoint(0);
					follower.distanceTravelled = 0f;
				}

				decider.path = 0;
			}

			if (decider.path == 2) //Right
			{
				if (right != null)
				{
					follower.pathCreator = right;
					transform.position = right.path.GetPoint(0);
					follower.distanceTravelled = 0f;
				}
				
				decider.path = 0;
			}
		}
	}
}
