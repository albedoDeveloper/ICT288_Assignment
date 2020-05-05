using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebox : MonoBehaviour
{
    [SerializeField] private PathFollower _train = null;
    [SerializeField] private float _trainDrag = 1;

    private float _speed = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoalPiece"))
        {
            Destroy(other.gameObject);
            _speed += 10;
            _train.speed = _speed;
        }
    }

    private void Update()
    {
        _speed -= _trainDrag * Time.deltaTime;
        if (_speed < 0)
        {
            _speed = 0;
        }
    }
}
