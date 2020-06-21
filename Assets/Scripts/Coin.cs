using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinManager;
    public float rotationSpeed;


    Transform myTransform;
    Vector3 myEuler = new Vector3(0,0,1);
    

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        coinManager = FindObjectOfType<CoinManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(myEuler, rotationSpeed);
    }

    public void CollectCoin()
    {
        coinManager.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
    }



}
