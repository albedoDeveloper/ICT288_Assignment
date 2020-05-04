using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Rigidbody ri;
	
	
	// Use this for initialization
	void Start () 
	{
		ri = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (ri.velocity.z < 1)
			//ri.AddForce(transform.forward * 5);
		Debug.Log(ri.velocity.z);

	}
}
