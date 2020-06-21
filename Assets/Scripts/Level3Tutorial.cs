using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Tutorial : MonoBehaviour
{
    [SerializeField] AudioClip _shootBarrels;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine("PlayVoice");
    }

    IEnumerator PlayVoice()
    {
        yield return new WaitForSeconds(2);
        _audioSource.clip = _shootBarrels;
        _audioSource.Play();
    }
}
