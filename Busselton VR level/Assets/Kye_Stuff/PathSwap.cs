using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class PathSwap : MonoBehaviour
{
	
	public PathCreator left, right, middle = null;
	public PathCreation.Examples.PathFollower follower = null;
	int path = 0;

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
		if (collider.tag == "Switch")
		{
			
			if (path == 1) //Left
			{
				if (left != null)
				{
					follower.pathCreator = left;
					transform.position = left.path.GetPoint(0);
					follower.distanceTravelled = 0f;
				}
			
				path = 0;
			}

			if (path == 2) //Right
			{
				if (right != null)
				{
					follower.pathCreator = right;
					transform.position = left.path.GetPoint(0);
					follower.distanceTravelled = 0f;
				}
				path = 0;
			}
		}
	}


	void OnTriggerStay(Collider collision)
	{	
		if (collision.tag == "RailSwitcher")
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				if (left != null)
					path = 1;
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				if (right != null)
					path = 2;
			}
		}
	}

}