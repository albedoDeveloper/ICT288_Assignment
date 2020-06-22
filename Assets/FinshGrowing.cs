using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshGrowing : MonoBehaviour
{
    void FinishGrowth()
    {
        GameObject.Find("GrowthCutScene").GetComponent<GrowthCutScene>().StartSeagullZoom();
    }
}
