using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class ReturnToMainTrack : MonoBehaviour {
	
	public PathCreator mainPath = null;
	public PathCreation.Examples.PathFollower follower = null;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider collider)
	{
		var currentPos = transform.position;
		
		if (collider.tag == "Train")
		{
				if (mainPath != null)
				{
					follower.pathCreator = mainPath;
					//transform.position = currentPos;
					follower.OnPathChanged();
				//transform.position = mainPath.path.GetPoint(0);
					
				
				//follower.distanceTravelled = 0f;
				}
		}
	}
}
