using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class ClearTrailRenderer : MonoBehaviour
{
    TrailRenderer tr;

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
    }

    void OnDisable()
    {
        if (tr != null)
            tr.Clear();
    }
}