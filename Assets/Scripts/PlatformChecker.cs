using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    [SerializeField] private GameObject _pcCharacter;
    [SerializeField] private GameObject _vrCharacter;

    void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _vrCharacter.SetActive(true);
            _pcCharacter.SetActive(false);
            Debug.Log("Android platform");
        }
        else
        {
            _vrCharacter.SetActive(false);
            _pcCharacter.SetActive(true);
            Debug.Log("PC Platform");
        }
    }
}
