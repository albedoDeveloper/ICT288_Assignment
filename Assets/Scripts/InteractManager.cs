using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    //class created by Brendon Smith.

    //private Collider _selection;

    private Outline _previousOutline;

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
            //if collider obj has outline script
            if (_hit.collider.GetComponent<Outline>() != null)
            {
                //if obj is Horn 
                if (_hit.collider.CompareTag("Horn"))
                {
                    _hit.collider.GetComponent<Outline>().enabled = true;
                    _previousOutline = _hit.collider.GetComponent<Outline>();
                }
                //if obj is CoalPile 
                if (_hit.collider.CompareTag("CoalPile"))
                {
                    _hit.collider.GetComponent<Outline>().enabled = true;
                    _previousOutline = _hit.collider.GetComponent<Outline>();
                }
                //if obj is Crossbow
                if (_hit.collider.CompareTag("Crossbow"))
                {
                    _hit.collider.GetComponent<Outline>().enabled = true;
                    _previousOutline = _hit.collider.GetComponent<Outline>();
                }
            }
            else
                if (_previousOutline != null)
            {
                _previousOutline.enabled = false;
            }

        }//end of Raycast
        else
            if (_previousOutline != null)
        {
            _previousOutline.enabled = false;
        }

    }//end of update

}//end of class

