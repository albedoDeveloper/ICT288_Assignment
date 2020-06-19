using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    Rigidbody _rb = null;
    int _health = 1;

    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void InitialPush(int force)
    {
        PushForward(force);
    }

    void PushForward(float force)
    {
        _rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            GameObject manager = GameObject.Find("Level3Manager");
            if (manager != null)
            {
                manager.GetComponent<Level3Manager>().AddCash(50);
            }
            Destroy(gameObject);
        }
    }
}
