using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowObstacle : MonoBehaviour
{
	[SerializeField] private PathCreation.Examples.PathFollower train = null;

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "Train")
		{
			//if (train.GetComponent<PathCreation.Examples.PathFollower>().speed > 0.5f)
			//             train.GetComponent<PathCreation.Examples.PathFollower>().speed = train.GetComponent<PathCreation.Examples.PathFollower>().speed - 0.4f;

			train.speed = 0;
		}
	}
}