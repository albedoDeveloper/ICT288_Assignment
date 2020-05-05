/*
 * Author: Robert Valentic
 */

using UnityEngine;

public class RGBButton : MonoBehaviour
{
    private Renderer _renderer = null;

    private void Start()
    {
        _renderer = transform.Find("Mesh").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color col = Color.Lerp(Color.cyan, Color.magenta, Mathf.Cos(Time.time * 10));
        _renderer.material.SetColor("_EmissionColor", col);
    }

}