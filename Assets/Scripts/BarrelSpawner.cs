using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
struct WaveInfo
{
    public int numOfBarrels;
    public int barrelSpeed;
    public float spawnRate;
}

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] GameObject _barrelPrefab;
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] WaveInfo[] _waves;
    [SerializeField] GameObject _waveBarPC;
    [SerializeField] GameObject _waveBarVR;
    [SerializeField] AudioClip[] _clips;
    int _currentWave = 1;
    int _barrelsLeft;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(7);
        StartCoroutine("SpawnBarrels");
        Debug.Log("Wave " + _currentWave + " started");
    }

    void UpdateWaveBarGUI()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _waveBarVR.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "WAVE: " + _currentWave;
            _waveBarVR.GetComponent<Slider>().value = _currentWave;
        }
        else
        {
            _waveBarPC.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "WAVE: " + _currentWave;
            _waveBarPC.GetComponent<Slider>().value = _currentWave;
        }
    }

    IEnumerator FinishWave()
    {
        Debug.Log("Wave " + _currentWave + " complete");
        yield return new WaitForSeconds(5);
        _currentWave++;
        UpdateWaveBarGUI();
        Debug.Log("Wave " + _currentWave + " started");
        StartCoroutine("SpawnBarrels");
    }

    IEnumerator SpawnBarrels()
    {
        _audioSource.clip = _clips[_currentWave - 1];
        _audioSource.Play();

        _barrelsLeft = _waves[_currentWave-1].numOfBarrels;

        while (true)
        {
            int index = Random.Range(0, _spawnPoints.Length);
            GameObject obj = Instantiate(_barrelPrefab, _spawnPoints[index]);
            obj.GetComponent<CapsuleCollider>().material.bounciness = Random.Range(0.0f, 1.0f);
            Barrel b = obj.GetComponent<Barrel>();
            if (b != null)
            {
                b.InitialPush(_waves[_currentWave-1].barrelSpeed);
            }
            _barrelsLeft--;
            if (_barrelsLeft <= 0)
            {
                yield return new WaitForSeconds(10);
                StartCoroutine("FinishWave");
                StopCoroutine("SpawnBarrels");
            }
            yield return new WaitForSeconds(_waves[_currentWave-1].spawnRate);
        }
    }
}
