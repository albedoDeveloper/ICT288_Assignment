using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    //class created by Brendon Smith.

    private Transform _selection;
    private Transform _toggledObject;

    private RaycastHit _hit;

    [SerializeField]
    Transform cam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if raycast intersects with a collider
        if (Physics.Raycast(cam.position, cam.forward, out _hit))
        {
            Debug.Log(_hit.transform.name);

            //if collider obj has outline script
            if (_hit.collider.GetComponent<Outline>() != null)
            {
                _selection = _hit.transform;
                _toggledObject = _hit.transform;

                //if obj is Horn obj
                if (_selection.CompareTag("Horn"))
                {
                    //_hit.transform.GetComponent<Outline>().enabled = true;
                    _selection.GetComponent<Outline>().enabled = true;
                }
                else
                    if (_selection.CompareTag("CoalPile"))
                    {
                        _selection.GetComponent<Outline>().enabled = true;
                    }
            }
            else
                if (_toggledObject.GetComponent<Outline>() != null)
                {
                    _toggledObject.transform.GetComponent<Outline>().enabled = false;
                }

        }//end of Raycast
        else
            if (_toggledObject.GetComponent<Outline>() != null)
            {
                _toggledObject.transform.GetComponent<Outline>().enabled = false;
            }

    }//end of update
    
}//end of class

