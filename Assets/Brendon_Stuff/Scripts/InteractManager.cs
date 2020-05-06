using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    //[SerializeField]
    //private string interactableTag = "Interactable";
    //[SerializeField]
    //private Outline testScript;

    private Transform _selection;
    private Transform _toggledObject;

    RaycastHit hit;

    [SerializeField]
    Transform cam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //selection
        if (Physics.Raycast(cam.position, cam.forward, out hit))
        {
            _selection = hit.transform;

            if (_selection.CompareTag("Interactable"))
            {
                hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                _toggledObject = hit.transform;
            }
            else
                _toggledObject.GetComponent<Outline>().enabled = false;
        }
    }
}

