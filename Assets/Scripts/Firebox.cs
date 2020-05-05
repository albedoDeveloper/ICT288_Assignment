/*
 * Author: Robert Valentic
 */

using PathCreation.Examples;
using UnityEngine;

public class Firebox : MonoBehaviour
{
    [SerializeField] float _temperature = 0;
    [SerializeField] private PathFollower _train = null;
    [SerializeField] private float _coolingRate = 2;
    [SerializeField] private float _maxTemp = 30;
    [SerializeField] TempGauge _tempGauge = null;
    [SerializeField] ParticleSystem _explosion = null;
    private Material _mat;

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
        }
    }

    private void Update()
    {
        _temperature -= _coolingRate * Time.deltaTime;
        _train.speed = _temperature;
        if (_temperature < 0)
        {
            _temperature = 0;
        }
        else if (_temperature > _maxTemp)
        {
            _temperature = _maxTemp;
            StopTrain();
        }
        SetEmissiveColour();
        _tempGauge.UpdatePointer(_temperature / _maxTemp);
    }

    private void StopTrain()
    {
        _explosion.Play();
        _temperature = 0;
        _train.speed = 0;
    }

    private void SetEmissiveColour()
    {
        _mat.SetColor("_EmissionColor", Color.Lerp(Color.black, Color.red, _temperature / _maxTemp));
    }
}
