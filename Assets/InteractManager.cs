using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    private Transform _selection;

    private RaycastHit _hit;

    [SerializeField]
    Transform cam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //selection
        if (Physics.Raycast(cam.position, cam.forward, out _hit))
        {
            _selection = _hit.transform;

            if (_selection.CompareTag("Interactable"))
            {
                _hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                _selection = _hit.transform;
                Debug.Log("Yeet");
            }
            if(_selection.CompareTag("CoalPile"))
            {
                _hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                _selection = _hit.transform;
                Debug.Log("Yeet2");
            }
            else
                _selection.GetComponent<Outline>().enabled = false;
            _testTransform.GetComponent<Outline>().enabled = false;
        }
    }
}

