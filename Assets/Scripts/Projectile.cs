/*
 * Author: Robert Valentic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed = 15;
    [SerializeField] AudioSource _niceShot;
    [SerializeField] GameObject _floatingTextPrefab;
    private Rigidbody _rb = null;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 15);
        _rb.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Target>() != null)
        {
            collision.collider.GetComponent<Target>().Knock();
            GetComponent<AudioSource>().Play();
            _niceShot.Play();
            Destroy(gameObject);
        }
        else if (collision.collider.GetComponent<Barrel>() != null)
        {
            DispPointText(10, transform.position);
            Destroy(gameObject);
            Destroy(collision.collider.gameObject, 5);
        }
    }

    void DispPointText(int points, Vector3 pointInWorld)
    {
        Instantiate(_floatingTextPrefab, pointInWorld, Quaternion.identity);
    }
}
