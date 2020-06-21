using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Tutorial : MonoBehaviour
{ 
    [SerializeField] AudioClip _pickupCoal;
    [SerializeField] AudioClip _throwCoal;
    [SerializeField] AudioClip _pullChain;
    [SerializeField] AudioClip _pickupCrossbow;
    [SerializeField] AudioClip _shootTargets;
    AudioSource _audioSource;
    bool _coalPickedUp = false;
    bool _hitBirds = false;
    bool _crossbowPickedUp = false;
    bool _chainPulled = false;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine("StartTutorial");
    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(2);
        PlayClip(_pickupCoal);
    }

    void PlayClip(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void CoalPickedUp()
    {
        if (!_coalPickedUp)
        {
            PlayClip(_throwCoal);
            _coalPickedUp = true;
        }
    }

    public void ChainPulled()
    {
        if (!_chainPulled)
        {
            PlayClip(_pickupCrossbow);
            _chainPulled = true;
        }
    }

    public void HitBirds()
    {
        if (!_hitBirds)
        {
            PlayClip(_pullChain);
            _hitBirds = true;
        }
    }

    public void CrossbowPickedUp()
    {
        if (!_crossbowPickedUp)
        {
            PlayClip(_shootTargets);
            _crossbowPickedUp = true;
        }
    }
}
