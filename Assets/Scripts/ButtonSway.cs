/*
 * Author: Robert Valentic
 */

using UnityEngine;

public class ButtonSway : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Mathf.Cos(Time.time) * Time.deltaTime) * 10);
    }

}
