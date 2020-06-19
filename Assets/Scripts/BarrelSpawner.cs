using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] GameObject _barrelPrefab;
    [SerializeField] Transform[] _spawnPoints;
    short _currentWave = 1;
    float _spawnInterval = 4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnBarrel");
    }



    IEnumerator SpawnBarrel()
    {
        while (true)
        {
            int index = Random.Range(0, _spawnPoints.Length);
            Instantiate(_barrelPrefab, _spawnPoints[index]);
            yield return new WaitForSeconds(_spawnInterval);
            _spawnInterval -= 0.4f;
        }
    }
}
