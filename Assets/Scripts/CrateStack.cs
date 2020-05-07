using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateStack : MonoBehaviour
{
    [SerializeField] private Firebox _fireBox = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Train"))
        {
            _fireBox.SetTemperatute(0);
            this.GetComponent<SphereCollider>().enabled = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
