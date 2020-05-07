/*
 * Author: Robert Valentic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullSoundLoop : MonoBehaviour
{
    AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        StartCoroutine("Play");
    }

    IEnumerator Play()
    {
        do
        {
            _audio.Play();
            yield return new WaitForSeconds(8);
        } while (true);
    }
}
