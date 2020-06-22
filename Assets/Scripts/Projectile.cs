/*
 * Author: Robert Valentic
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed = 15;
    [SerializeField] AudioSource _niceShot;
    [SerializeField] GameObject _floatingTextPrefab;
    [SerializeField] int _damage = 1;
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
            collision.collider.GetComponent<Barrel>().TakeDamage(_damage);
        }
        else if (collision.collider.GetComponent<Powerup>() != null)
        {
            collision.collider.GetComponent<Powerup>().Purchase();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Coin>() != null)
        {
            Debug.Log("Dooby doo");
            collision.GetComponent<Coin>().CollectCoin();
        }
    }

    void DispPointText(int points, Vector3 pointInWorld)
    {
        GameObject obj = Instantiate(_floatingTextPrefab, pointInWorld, Quaternion.identity);
        FloatingText ft = obj.GetComponent<FloatingText>();
        if (ft != null)
        {
            //ft.SetText(points); // TODO this is causing an elusive error
        }
    }
}
