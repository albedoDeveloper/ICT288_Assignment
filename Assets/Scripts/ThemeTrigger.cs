using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _steamTrain = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Train"))
        {
            GetComponent<AudioSource>().Play();
            other.GetComponent<AudioSource>().Stop();
            _steamTrain.Stop();
        }
    }
}
