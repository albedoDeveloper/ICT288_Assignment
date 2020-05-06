using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class Gui : MonoBehaviour {

    [HideInInspector]
    public float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        timer += Time.deltaTime;
        GetComponent<TextMeshProUGUI>().text = Math.Round(timer,1).ToString();

    }

}
