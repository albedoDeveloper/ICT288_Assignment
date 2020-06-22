using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private Vector3 WayPointPosition = new Vector3(0,0,0);
    public Vector3 Offset = new Vector3(0,10,0);

    public float Amplitude = 1;
    public float Frequency = 1;

    // Start is called before the first frame update
    void Start()
    {
        WayPointPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    public void SetPosition(Vector3 position)
    {
        WayPointPosition = position;
    }

    void UpdatePosition()
    {
        Vector3 newPosition = WayPointPosition;
        float level = SinWave(Time.time);
        newPosition.y += level;
        this.transform.position = newPosition + Offset;
    }

    float SinWave(float time, float phase = 0)
    {
        return Amplitude * Mathf.Sin(2 * Mathf.PI * Frequency * time + phase);
    }

}
