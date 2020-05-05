using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebox : MonoBehaviour
{
    [SerializeField] private PathFollower _train = null;
    [SerializeField] private float _coolingRate = 2;
    [SerializeField] private float _maxTemp = 30;

    private Material _mat;
    [SerializeField] private float _temperature = 0;

    private void Start()
    {
        _mat = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CoalPiece"))
        {
            Destroy(other.gameObject);
            _temperature += 10;
            _train.speed = _temperature;
        }
    }

    private void Update()
    {
        _temperature -= _coolingRate * Time.deltaTime;
        if (_temperature < 0)
        {
            _temperature = 0;
        }
        else if (_temperature > _maxTemp)
        {
            _temperature = _maxTemp;
        }
        SetEmissiveColour();
    }

    private void SetEmissiveColour()
    {
        _mat.SetColor("_EmissionColor", Color.Lerp(Color.black, Color.red, _temperature / _maxTemp));
    }
}
