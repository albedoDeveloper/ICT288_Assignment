using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveSpawner : MonoBehaviour
{
    [SerializeField] GameObject _swervyBarrel;
    [SerializeField] Transform[] _spawn;
    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Instantiate(_swervyBarrel, _spawn[i % 2]);
            i++;
        }
    }
}
