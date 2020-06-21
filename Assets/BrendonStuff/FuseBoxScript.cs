using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxScript : MonoBehaviour
{
    [SerializeField] private Transform _light1;
    [SerializeField] private Transform _light2;
    [SerializeField] private Transform _light3;

    [SerializeField] private Transform _fuseBox;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }//end of Update()

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>() != null)
        {
            _audioSource.Play();

            //turn off the spotlight and lightshape for light1
            _light1.GetChild(0).transform.gameObject.SetActive(true);
            _light1.GetChild(1).transform.gameObject.SetActive(true);

            //turn off the spotlight and lightshape for light2
            _light2.GetChild(0).transform.gameObject.SetActive(true);
            _light2.GetChild(1).transform.gameObject.SetActive(true);

            //turn off the spotlight and lightshape for light3
            _light3.GetChild(0).transform.gameObject.SetActive(true);
            _light3.GetChild(1).transform.gameObject.SetActive(true);
        }//end of if statement

    }//end of OnCollisionEnter function

}//end of class.
