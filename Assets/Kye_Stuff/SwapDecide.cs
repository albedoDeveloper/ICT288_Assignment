using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SwapDecide : MonoBehaviour {

	[HideInInspector]
	public int path = 0;
	
	public PathCreator left, right = null;
	public bool swapLeft, swapRight;

	public void SwapTrack()
	{
		if (swapLeft && (left != null))
		{
			path = 1;
		}
		else if (swapRight && (right != null))
		{
			path = 2;
		}
	}
}
