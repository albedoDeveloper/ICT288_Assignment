using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SwapDecide : MonoBehaviour {

	[HideInInspector]
	public int path = 0;
	
	public PathCreator left, right = null;
	public bool swapLeft, swapRight;

	//void OnTriggerStay(Collider collision)
	//{
	//	Debug.Log("Collides");
	//	if (collision.tag == "Train")
	//	{
	//		if (Input.GetKey(KeyCode.LeftArrow) && swapLeft)
	//		{

	//			if (left != null)
	//				path = 1;
	//		}

	//		if (Input.GetKey(KeyCode.RightArrow) && swapRight)
	//		{
	//			if (right != null)
	//				path = 2;
	//		}
	//	}
	//}

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
