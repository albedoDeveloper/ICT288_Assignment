using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButton : MonoBehaviour
{
    Image _img;

    void Start()
    {
        _img = GetComponent<Image>();
    }

    public void Hover()
    {
        if (_img != null)
        {
            _img.color = Color.green;
        }
    }

    public void UnHover()
    {
        if (_img != null)
        {
            _img.color = Color.white;
        }
    }

    public virtual void Press()
    {

    }
}
