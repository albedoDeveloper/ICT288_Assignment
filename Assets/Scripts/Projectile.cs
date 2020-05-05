/*
 * Author: Robert Valentic
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 15;
    private Rigidbody _rb = null;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 15);
        _rb.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rb.velocity = -transform.forward;

        if (collision.collider.name == "Target")
        {
            Animator anim = collision.collider.GetComponent<Animator>();
            anim.SetTrigger("Fall");
        }
    }
}
