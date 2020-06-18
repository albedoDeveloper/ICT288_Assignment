using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFix : MonoBehaviour
{
    [SerializeField] private MenuOptions _mo;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                Debug.Log("You selected the " + hit.collider.name); // ensure you picked right object

                if (hit.collider.name == "InstructionsButton")
                {
                    _mo.Instructions();
                } 
                else if (hit.collider.name == "NewGameButton")
                {
                    _mo.NewGame();
                }
                else if (hit.collider.name == "LoadGameButton")
                {
                    _mo.LoadGame();
                }
            }
        }
    }
   
}
