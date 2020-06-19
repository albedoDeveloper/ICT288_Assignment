using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class FloatingText : MonoBehaviour
{
    float _fadeRate = 0.5f;
    TextMeshProUGUI _tmp;

    // Start is called before the first frame update
    void Start()
    {
        _tmp = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 10 * Time.deltaTime);
        _tmp.color = new Color(_tmp.color.r, _tmp.color.g, _tmp.color.b, _tmp.color.a - _fadeRate * Time.deltaTime);
    }
}
