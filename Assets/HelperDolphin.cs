using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperDolphin : MonoBehaviour
{
    public void DropShroom()
    {
        Debug.Log("Shroom dropped");
        transform.Find("Shroom").gameObject.SetActive(true);
    }
}
