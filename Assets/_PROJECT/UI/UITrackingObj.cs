using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrackingObj : MonoBehaviour
{
    public Transform worldObj;
    public RectTransform rect;

    void LateUpdate()
    {
        if (worldObj == null)
            return;

        rect.position = RectTransformUtility.WorldToScreenPoint(Camera.main, worldObj.position);
    }
}
