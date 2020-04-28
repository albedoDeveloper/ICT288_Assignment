using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Gui : MonoBehaviour {

    [HideInInspector]
    public float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		timer = timer + 0.01f;
		
	}

	void OnGUI()
	{
		GUILayout.Label(Math.Round(timer,2).ToString());
	}
}
