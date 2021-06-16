using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererSortingOrder : MonoBehaviour
{
    TrailRenderer trail;
    public int order;

    // Use this for initialization
    void Start()
    {
        trail = GetComponent<TrailRenderer>();

        if (trail != null)
        {
            trail.sortingOrder = order;
        }
    }
}