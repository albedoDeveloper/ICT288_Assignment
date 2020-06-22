using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheckForWater : MonoBehaviour
{
    [SerializeField]
    private Transform _VRWater;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if(_VRWater != null)
            {
                _VRWater.GetChild(0).transform.gameObject.SetActive(true);
            }
        }
        else
        {
            if (_VRWater != null)
            {
                _VRWater.GetChild(1).transform.gameObject.SetActive(true);
            }
        }
    }
}
