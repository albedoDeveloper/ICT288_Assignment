using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SpeedModifier : MonoBehaviour {

    public GameObject train;
	[HideInInspector]
	public float accel = 0.03f;
	
	// Use this for initialization
	
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		//if (transform.position.y < transform.parent.position.y + 0.4f)
		//transform.position = new Vector3(transform.parent.position.x + 0.5f, transform.parent.position.y, transform.parent.position.z);
	}

		
	void OnMouseDrag()
	{

		if (train.GetComponentInParent<PathCreation.Examples.PathFollower>().speed < 20)
            train.GetComponentInParent<PathCreation.Examples.PathFollower>().speed = train.GetComponentInParent<PathCreation.Examples.PathFollower>().speed + accel;                           

	}
}
