using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private SwapDecide _swapper = null;

    public void Knock()
    {
        _swapper.SwapTrack();
    }
}
